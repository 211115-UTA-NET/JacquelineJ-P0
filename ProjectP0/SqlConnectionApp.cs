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
        public string sqlProperties()
        {
            StringBuilder stringbuilderObject = new StringBuilder();
            string path = "C:\\Users\\ashwi\\OneDrive\\Desktop\\.NET\\PROJECT0\\DBproperties.txt";
            StreamReader reader = new StreamReader(path);
            stringbuilderObject.Append("Data Source=2111-sql-jack.database.windows.net;Initial Catalog=jackie_Project0DB;Persist Security Info=False;User ID=");
            stringbuilderObject.Append(reader.ReadLine());
            stringbuilderObject.Append("; Password =");
            stringbuilderObject.Append(reader.ReadLine());
            reader.Close();
            string connectStr= stringbuilderObject.ToString();

            return (connectStr);


        }

        public SqlConnection DBConnection(string connectString_)
        {

            string connectString = sqlProperties();
            SqlConnection conn = new SqlConnection(connectString);
            try
            {
                Console.WriteLine("Connecting to databse...");
                conn.Open();
                Console.WriteLine("Connected Successfully");
            } catch (Exception ex) {
                Console.WriteLine("Not connected because of the error : ",ex.Message);
            }
            return conn;
        }
        /*
        public string Insert(string sqlQuery)
        {
            SqlConnection? conn = DBConnection();
            try
            {
               /* StringBuilder stringbuilderObject = new StringBuilder();
                stringbuilderObject.Append("INSERT INTO Customer (CustomerId,CustomerFirstName,CustomerLastName) VALUES");
                stringbuilderObject.Append("(11012,'Jane','Potter'),");
                stringbuilderObject.Append("(11013,'Mat','Chip'),");
                stringbuilderObject.Append("(11014,'Diana','Small')");

                string sqlQuery = stringbuilderObject.ToString();*/

                /*using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
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

        public string Fetch(string sqlQuery)
        {
            SqlConnection conn = DBConnection();
            try
            {
               /* StringBuilder stringbuilderObject = new StringBuilder();
                //stringbuilderObject.Append("Select * from Customer");
                stringbuilderObject.Append("Select * from Customer where CustomerFirstName= 'Faith'");
                
                string sqlQuery = stringbuilderObject.ToString();*/

                /*SqlCommand command = new SqlCommand(sqlQuery, conn);
              
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} {1} {2}",
                          reader[0], reader[1] ,reader[2]));
                    }
                    Console.WriteLine("Sql query execution :", sqlQuery);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : ", ex.Message);
            }
            finally { conn.Close(); }


            return "Query Executed";
    


        }*/
    }

    
}
