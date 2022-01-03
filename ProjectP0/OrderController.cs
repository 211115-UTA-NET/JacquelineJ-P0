using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class OrderController : IInsertInTables
    {

        public void addOrderNew()
        {

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            string sqlQuery;
            StringBuilder stringbuilderObject = new StringBuilder();
            Console.WriteLine("Select customer from below customers ");
            CustomerController customerController = new CustomerController();
            List<Customer> customerList = customerController.getCustomers(null);
            foreach (Customer customer in customerList)
            {
                Console.WriteLine("Customer-Id: " + customer.Customer_Id + "  Customer_FirstName: " + customer.Customer_FirstName + " Customer_LastName: " + customer.Customer_LastName + " Customer_City " + customer.Customer_City + " Customer_City " + customer.Customer_State);
            }
            Console.WriteLine("Please Select CustomerId");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Available Stores for placing order");
            //write code to get store details
            //SELECT DISTINCT(S.STOREID) ,S.StoreName,S.S_Address,S.ZipCode FROM STORE AS S,Product AS P   WHERE P.StoreId = S.StoreId;
            //SELECT DISTINCT(S.STOREID) ,S.StoreName FROM STORE AS S,Product AS P   WHERE P.StoreId = S.StoreId;
            StoreController storeController = new StoreController();
            List<Store> storeList = storeController.getStores();

            foreach (Store item in storeList)
            {
                Console.WriteLine("Store_Id: " + item.StoreId + "  Store_Name: " + item.StoreName);
            }
            Console.WriteLine("Please Select storeId");
            string storeId = Console.ReadLine();


            List<Product> productList = getProduts(storeId);

            foreach (Product item in productList)
            {
                Console.WriteLine("Product_Id: " + item.ProductId + "  Product_Name: " + item.ProductName + " Product_Price: " + item.ProductPrice + " Product_Availability: " + item.ProductQuantity);
            }

            Console.WriteLine("Please Enter Product_Id:");
            int product_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter Product quantity:");
            int product_Quantity = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Do you want to enter more Products")

            //PLACE ORDER BY UPDATE PRODUCT TABLE, INSERT ORDER TABLE AND INSERT ORDERDETAILS TABLE
            //UPDATE PRODUCT TABLE
            ProductController productController = new ProductController();
            int currentProductQuantity = getNewProdQuantity(productList, product_Id);
            String selectedProductName = getProdName(productList, product_Id);

            int prod_NewQuantity = currentProductQuantity - product_Quantity;
            if (prod_NewQuantity > 0)
            {
                productController.updateProductQuantity(product_Id, prod_NewQuantity);
            }

            //INSERT ORDER TABLE
            Console.WriteLine("OrderController - addNewOrder - Insert into Order Table.. ");
            int orderId = addToOrder(customerId);
            Console.WriteLine("Order - CREATED - OrderId: "+orderId);

            //INSERT ORDERDETAILS TABLE
            Console.WriteLine("OrderController - addNewOrder - Insert into Order Table.. ");
            addToOrderDetails(orderId, product_Id, selectedProductName, Convert.ToInt32(storeId), product_Quantity);

        }

        private void addToOrderDetails(int orderId, int productId, string selectedProductName, int storeId, int product_Quantity)
        {
            //insert into Customer (CustomerFirstName, CustomerLastName, C_Address1, C_Address2) values
            //('Tom', 'Hanks', 'Enfield', 'CT');
            Console.WriteLine("In OrderController - addToOrderDetails orderId- "+ orderId + " ProdId- "+ productId + " Prodname- "+ selectedProductName + " StoreId- "+storeId + "ProdQuan- "+product_Quantity);

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            
            using (connectionObj)
            {
                // Query to be executed
                string queryString = "Insert into OrderDetails (OrderId, Pro_ID, Pro_Name, Store_ID, Quantity) Values "
                 + "(@OrderId, @Pro_ID, @Pro_Name, @Store_ID, @Quantity)";
                
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connectionObj);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@Pro_ID", productId);
                    command.Parameters.AddWithValue("@Pro_Name", selectedProductName);
                    command.Parameters.AddWithValue("@Store_ID", storeId);
                    command.Parameters.AddWithValue("@Quantity", product_Quantity);
                    Console.WriteLine("OrderController addOrderDetial query : " + queryString);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { connectionObj.Close(); }
            }            
        }

        public int addToOrder(int customerId)
        {
            Console.WriteLine("In OrdereController - addToOrder ");

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            int orderId = 0;
            using (connectionObj)
            {
               
                // Query to be executed
                string queryString = "Insert into Order_ (Cus_ID) Values "
                 + "(@Cus_ID)";
                queryString += " SELECT SCOPE_IDENTITY()";
                SqlCommand command = new SqlCommand(queryString, connectionObj);
                command.Parameters.AddWithValue("@Cus_ID", customerId);
                SqlParameter orderedId = new SqlParameter("@OrderID", SqlDbType.Int);
                orderedId.Direction = ParameterDirection.Output;
                command.Parameters.Add(orderedId);


                Console.WriteLine("OrderController addOrder query : "+ queryString);
                try
                {
                    orderId = Convert.ToInt32(command.ExecuteScalar()); 
                    //command.ExecuteNonQuery();                   
                    Console.WriteLine("OrderController addOrder - ExecuteScalar - orderId: "+ orderId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { connectionObj.Close(); }               
            }
            return orderId;
        }

        private int getNewProdQuantity(List<Product> productList, int product_Id)
        {
            foreach (Product item in productList)
            {
                if (item.ProductId == product_Id)
                    return item.ProductQuantity;
            }
            return 0;
        }

        private string getProdName(List<Product> productList, int product_Id)
        {
            foreach (Product item in productList)
            {
                if (item.ProductId == product_Id)
                    return item.ProductName;
            }
            return null;
        }

        private List<Product> getProduts(string storeId)
        {
            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            string sqlQuery;
            StringBuilder stringbuilderObject = new StringBuilder();

            List<Product> productList = new List<Product>();
            using (connectionObj)
            {
                // Query to be executed
                int id = Convert.ToInt32(storeId);
                string queryString = "SELECT p.PRODUCTID, p.PRODUCTNAME,p.PRODUCTPRICE,p.PRODUCTQUANTITY FROM PRODUCT p WHERE p.StoreId = @store_Id";
               SqlCommand command = new SqlCommand(queryString, connectionObj);

                int s_id = Convert.ToInt32(storeId);
                //stringbuilderObject.Append(" and o.orderid = @storeId");
                //command = new SqlCommand(stringbuilderObject.ToString(), connectionObj);
                command.Parameters.AddWithValue("@store_Id",s_id);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Product obj;
                    while (reader.Read())
                    {
                        obj = new Product();
                        obj.ProductId = reader.GetInt32(0);
                        obj.ProductName = reader.GetString(1);
                        obj.ProductPrice = reader.GetDecimal(2);
                        obj.ProductQuantity = reader.GetInt32(3);
                        productList.Add(obj);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Query Not Executed : " + ex.Message);
                }
                finally { connectionObj.Close(); }

                return productList;
            }
        }




        public void getOrders(string orderId)
        {
            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            List<Orders> orderList = new List<Orders>();

            string orderSelectQuery = "Select * from Orders";

            StringBuilder stringBuilderObj = new StringBuilder();
            stringBuilderObj.Append(orderSelectQuery);
            if (orderId != null && orderId.Length > 0)
            {
                int id = Convert.ToInt32(orderId);
                stringBuilderObj.Append(" Where orderid = " + orderId);
            }
            string query = stringBuilderObj.ToString();

            //Console.WriteLine("OrderController : results : Fetching from Order table : " + query);
            try
            {
                SqlDataReader reader = objDB.FetchProducts(query, connectionObj);
                Orders orderObj;

                using (reader)
                {
                    while (reader.Read())
                    {
                        orderObj = new Orders();
                        orderObj.Order_Id = reader.GetInt32(0);
                        orderObj.Cust_Id = reader.GetInt32(1);
                        orderObj.Order_Time = reader.GetDateTime(2);
                        orderList.Add(orderObj);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }
            foreach (Orders item in orderList)
            {
                Console.WriteLine("Order-Id: " + item.Order_Id + "  Customer-Id: " + item.Cust_Id + " Order time: " + item.Order_Time);

            }
            //Console.WriteLine("Fetch Complete...");

        }
    }
}
