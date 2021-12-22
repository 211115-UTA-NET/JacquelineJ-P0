using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class SqlConnectionApp
    {
        private string sqlProperties()
        {
            StringBuilder stringbuilderObject = new StringBuilder();
            string path = "C:\\Users\\ashwi\\OneDrive\\Desktop\\.NET\\PROJECT0\\DBproperties.txt";
            StreamReader reader = new StreamReader(path);
            stringbuilderObject.Append("Data Source=2111-sql-jack.database.windows.net;Initial Catalog=jackie_Project0DB;Persist Security Info=False;User ID=");
            stringbuilderObject.Append(reader.ReadLine());
            stringbuilderObject.Append("; Password =");
            stringbuilderObject.Append(reader.ReadLine());
            reader.Close();
            string connectStr = stringbuilderObject.ToString();
            return (connectStr);
        }

        public SqlConnection DBConnection()
        {

            string connectString = sqlProperties();
            SqlConnection conn = new SqlConnection(connectString);
            try
            {
                Console.WriteLine("Connecting to databse...");
                conn.Open();
                Console.WriteLine("Connected Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not connected because of the error : ", ex.Message);
            }
            return conn;
        }

        public string Insert(string sqlQuery, SqlConnection conn)
        {
            if (conn is null || sqlQuery is null)
            {
                return "do nothing as connection object is null";
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    Console.WriteLine("Sql query execution : ", sqlQuery);
                    cmd.ExecuteNonQuery();                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : ", ex.Message);
            }
            finally { conn.Close(); }

            return "Query Executed";
        }

        /* public List<Customer> Fetch(string sqlQuery, SqlConnection conn)
         {
             List<Customer> customerList = new List<Customer>();
             if (conn is null || sqlQuery is null)
             {
                 return customerList;
             }

             try
             {
                 SqlCommand command = new SqlCommand(sqlQuery, conn);
                 Customer customerObj = null;
                 using (SqlDataReader reader = command.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         customerObj = new Customer();
                         customerObj.customer_Id = reader.GetInt32(0);
                         customerObj.customer_FirstName = reader.GetString(1);
                         customerList.Add(customerObj);

                     }
                     Console.WriteLine("Sql query execution :", sqlQuery);

                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(" Query Not Executed : ", ex.Message);
             }
             finally { conn.Close(); }

             return customerList;

         }

         /* public List<Orders> Fetch(string sqlQuery, SqlConnection conn)
          {
              List<Orders> orderList = new List<Orders>();
              if (conn is null || sqlQuery is null)
              {
                  return null;
              }
              /*orderList.customer_Id = reader.GetInt32(0);
                          orderList.customer_FirstName = reader.GetString(1);
                          orderList.Add(customerObj);*/
        /*
             try
             {
                 SqlCommand command = new SqlCommand(sqlQuery, conn);
                 Orders orderObj = null;
                 using (SqlDataReader reader = command.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         orderObj = new Orders();
                         orderList.OrderID = reader.GetInt32(0);
                         orderList.CustomerId = reader.GetInt32(0);
                         orderList.ProductId = reader.GetInt32(0);
                         orderList.Quantity = reader.GetInt32(0);
                         orderList.Add(orderObj);
                     }
                     Console.WriteLine("Sql query execution :", sqlQuery);

                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(" Query Not Executed : ", ex.Message);
             }
             finally { conn.Close(); }

             return orderList;
         }*/

        public SqlDataReader FetchProducts(string sqlQuery, SqlConnection conn)
        {
            List<Product> productList = new List<Product>();
            SqlDataReader reader = null;
            if (conn is null || sqlQuery is null)
            {
                return null;
            }

            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                Console.WriteLine("Sql query execution :"+ sqlQuery);
                reader = command.ExecuteReader();
                return reader;                       
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : "+ ex.Message);
            }
            
            return reader;

        }
    }

    
}
