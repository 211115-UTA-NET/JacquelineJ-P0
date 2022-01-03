using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class OrderDetailsControllers
    {
        public void getOrderDetails(string orderId)
        {
            Console.WriteLine("getting order details by orderId "+ orderId);

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            List<OrderDetails> orderList = new List<OrderDetails>();
            using (connectionObj)
            {     
                // Query to be executed
                string queryString = "SELECT o.OrderID, o.Cus_ID, c.CustomerFirstName, c.CustomerLastName,d.Pro_ID, d.Pro_Name, d.Quantity, s.StoreId, s.StoreName, o.Order_TIME "
                + "FROM order_ o, OrderDetails d, Customer c, Store s "
                + "WHERE o.OrderID = d.OrderID "
                + "and o.Cus_ID = c.CustomerId and d.Store_ID = s.StoreId ";

                StringBuilder stringbuilderObject = new StringBuilder();
                stringbuilderObject.Append(queryString);
                SqlCommand command ; 
                if (orderId != null && orderId.Length > 0)
                {
                    int id = Convert.ToInt32(orderId);
                    stringbuilderObject.Append(" and o.orderid = @orderId");                     
                    command = new SqlCommand(stringbuilderObject.ToString(), connectionObj);
                    command.Parameters.AddWithValue("@orderId", id);
                }
                else
                {
                    command = new SqlCommand(queryString, connectionObj);
                }

                Console.WriteLine("OrderController : Query : ");
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    OrderDetails orderObj;
                    while (reader.Read())
                    {
                        orderObj = new OrderDetails();
                        orderObj.Order_Id = reader.GetInt32(0);
                        orderObj.Cust_ID = reader.GetInt32(1);
                        orderObj.Cust_FName = reader.GetString(2);
                        orderObj.Cust_LName = reader.GetString(3);
                        orderObj.Prod_Id = reader.GetInt32(4);
                        orderObj.Prod_Name = reader.GetString(5);
                        orderObj.prod_Quantity = reader.GetInt32(6);
                        orderObj.Store_Id = reader.GetInt32(7);
                        orderObj.Store_Name = reader.GetString(8);
                        orderObj.Order_Time = reader.GetDateTime(9);
                        orderList.Add(orderObj);
                    }                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Query Not Executed : " + ex.Message);
                }
                finally { connectionObj.Close(); }
                foreach (OrderDetails item in orderList)
                {
                    Console.WriteLine("Order_Id: " + item.Order_Id + "  Customer_Id: " + item.Cust_ID + " Customer FirstName: " + item.Cust_FName + " Customer LastName: " + item.Cust_LName +
                        " Product_Id: " + item.Prod_Id + " Product_Name: " + item.Prod_Name + " Product_Quantity: " + item.prod_Quantity + " Store_Id: " + item.Store_Id +
                        " Store_Name: " + item.Store_Name + " Order_time: " + item.Order_Time);

                }
                Console.WriteLine("Fetch Complete...");

            }

        }

        public void getOrdersByStore(string storeId)
        {
            Console.WriteLine("getting order details by orderId " + storeId);

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            List<OrderDetails> orderList = new List<OrderDetails>();
            using (connectionObj)
            {
                // Query to be executed
                string queryString = "SELECT o.OrderID, o.Cus_ID, c.CustomerFirstName, c.CustomerLastName,d.Pro_ID, d.Pro_Name, d.Quantity, s.StoreId, s.StoreName, o.Order_TIME "
                + "FROM order_ o, OrderDetails d, Customer c, Store s "
                + "WHERE o.OrderID = d.OrderID "
                + "and o.Cus_ID = c.CustomerId and d.Store_ID = s.StoreId ";

                StringBuilder stringbuilderObject = new StringBuilder();
                stringbuilderObject.Append(queryString);
                SqlCommand command;
                if (storeId != null && storeId.Length > 0)
                {
                    int id = Convert.ToInt32(storeId);
                    stringbuilderObject.Append(" and s.StoreId = @StoreId");
                    command = new SqlCommand(stringbuilderObject.ToString(), connectionObj);
                    command.Parameters.AddWithValue("@StoreId", id);
                }
                else
                {
                    command = new SqlCommand(queryString, connectionObj);
                }

                Console.WriteLine("OrderController : Query : ");
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    OrderDetails orderObj;
                    while (reader.Read())
                    {
                        orderObj = new OrderDetails();
                        orderObj.Order_Id = reader.GetInt32(0);
                        orderObj.Cust_ID = reader.GetInt32(1);
                        orderObj.Cust_FName = reader.GetString(2);
                        orderObj.Cust_LName = reader.GetString(3);
                        orderObj.Prod_Id = reader.GetInt32(4);
                        orderObj.Prod_Name = reader.GetString(5);
                        orderObj.prod_Quantity = reader.GetInt32(6);
                        orderObj.Store_Id = reader.GetInt32(7);
                        orderObj.Store_Name = reader.GetString(8);
                        orderObj.Order_Time = reader.GetDateTime(9);
                        orderList.Add(orderObj);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Query Not Executed : " + ex.Message);
                }
                finally { connectionObj.Close(); }
                foreach (OrderDetails item in orderList)
                {
                    Console.WriteLine("Order_Id: " + item.Order_Id + "  Customer_Id: " + item.Cust_ID + " Customer FirstName: " + item.Cust_FName + " Customer LastName: " + item.Cust_LName +
                        " Product_Id: " + item.Prod_Id +  " Product_Name: " + item.Prod_Name + " Product_Quantity: " + item.prod_Quantity +  " Store_Id: " + item.Store_Id +
                        " Store_Name: " + item.Store_Name + " Order_time: " + item.Order_Time);

                }
                Console.WriteLine("Fetch Complete...");

            }

        }

        public void getOrdersByCustomer(string customerId)
        {
            Console.WriteLine("getting order details by orderId " + customerId);

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            List<OrderDetails> orderList = new List<OrderDetails>();
            using (connectionObj)
            {
                // Query to be executed
                string queryString = "SELECT o.OrderID, o.Cus_ID, c.CustomerFirstName, c.CustomerLastName,d.Pro_ID, d.Pro_Name, d.Quantity, s.StoreId, s.StoreName, o.Order_TIME "
                + "FROM order_ o, OrderDetails d, Customer c, Store s "
                + "WHERE o.OrderID = d.OrderID "
                + "and o.Cus_ID = c.CustomerId and d.Store_ID = s.StoreId ";

                StringBuilder stringbuilderObject = new StringBuilder();
                stringbuilderObject.Append(queryString);
                SqlCommand command;
                if (customerId != null && customerId.Length > 0)
                {
                    int id = Convert.ToInt32(customerId);
                    stringbuilderObject.Append(" and c.CustomerId = @customerId");
                    command = new SqlCommand(stringbuilderObject.ToString(), connectionObj);
                    command.Parameters.AddWithValue("@customerId", id);
                }
                else
                {
                    command = new SqlCommand(queryString, connectionObj);
                }

                Console.WriteLine("OrderController : Query : ");
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    OrderDetails orderObj;
                    while (reader.Read())
                    {
                        orderObj = new OrderDetails();
                        orderObj.Order_Id = reader.GetInt32(0);
                        orderObj.Cust_ID = reader.GetInt32(1);
                        orderObj.Cust_FName = reader.GetString(2);
                        orderObj.Cust_LName = reader.GetString(3);
                        orderObj.Prod_Id = reader.GetInt32(4);
                        orderObj.Prod_Name = reader.GetString(5);
                        orderObj.prod_Quantity = reader.GetInt32(6);
                        orderObj.Store_Id = reader.GetInt32(7);
                        orderObj.Store_Name = reader.GetString(8);
                        orderObj.Order_Time = reader.GetDateTime(9);
                        orderList.Add(orderObj);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Query Not Executed : " + ex.Message);
                }
                finally { connectionObj.Close(); }
                foreach (OrderDetails item in orderList)
                {
                    Console.WriteLine("Order_Id: " + item.Order_Id + "  Customer_Id: " + item.Cust_ID + " Customer FirstName: " + item.Cust_FName + " Customer LastName: " + item.Cust_LName +
                        " Product_Id: " + item.Prod_Id + " Product_Name: " + item.Prod_Name + " Product_Quantity: " + item.prod_Quantity + " Store_Id: " + item.Store_Id +
                        " Store_Name: " + item.Store_Name + " Order_time: " + item.Order_Time);

                }
                Console.WriteLine("Fetch Complete...");

            }

        }
    }
}
