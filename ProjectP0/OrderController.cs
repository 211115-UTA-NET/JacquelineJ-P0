using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class OrderController : IInsertInTables
    {

        public void add()
        {

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            string sqlQuery;

            StringBuilder stringbuilderObject = new StringBuilder();

            Console.WriteLine("Enter Order Details Customer ID, Product ID, Qunatity");
            string Cus_ID = Console.ReadLine();
            string Product_ID = Console.ReadLine();
            string Qunatity = Console.ReadLine();
            
            stringbuilderObject.Append("INSERT INTO Orders (CustomerId,ProductID,Quantity) VALUES");
            stringbuilderObject.Append("(" + Cus_ID + "," + Product_ID + "," + Qunatity +")");
            sqlQuery = stringbuilderObject.ToString();

            //Console.WriteLine("Insert Orders query : "+sqlQuery);
            objDB.Insert(sqlQuery, connectionObj);
            //Console.WriteLine("Insert Complete...");

            
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
                Orders orderObj = null;

                using (reader)
                {
                    while (reader.Read())
                    {
                        orderObj = new Orders();
                        orderObj.OrderID = reader.GetInt32(0);
                        orderObj.CustomerId = reader.GetInt32(1);
                        orderObj.ProductId = reader.GetInt32(2);
                        orderObj.Quantity = reader.GetInt32(3);
                        orderObj.OrderTime = reader.GetDateTime(4);
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
                Console.WriteLine("Order-Id: " + item.OrderID + "  Customer-Id: " + item.CustomerId + " Product-Id: " + item.ProductId + " Quantity :  " +item.Quantity);

            }
            //Console.WriteLine("Fetch Complete...");

        }
    }
}
