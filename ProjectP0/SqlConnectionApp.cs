using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class SqlConnectionApp
    {
        public string DatabaseConn()
        {
            // var dataSource = "2111-sql-jack.database.windows.net";
            //var dataBase = "jackie_Project0DB";
            //var userName = "SQLDBADMIN";
            //var password = "MyFav1234%";

            string connectString = @"Server=tcp:2111-sql-jack.database.windows.net,1433;Initial Catalog=2111-sql-jack;Persist Security Info=False;User ID=SQLDBADMIN;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnection conn = new SqlConnection(connectString);

            try
            {
                Console.WriteLine("Connecting to databse...");
                conn.Open();
                Console.WriteLine("Connected Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Not Connected : ", ex.Message);
            }

            StringBuilder stringbuilderObject = new StringBuilder();
            stringbuilderObject.Append("INSER INTO Customer (CustomerId,CustomerFirstName,CustomerLastName) VALUES");
            //("(N'Harsh', N'harsh@gmail.com', N'Class X'), ");
            stringbuilderObject.Append("(N'1109,N'Maggie',N'Dun'),");
            stringbuilderObject.Append("(N'11010,N'Ruth',N'Chip'),");
            stringbuilderObject.Append("(N'11011,N'Rose',N'Small'),");

            string sqlQuery = stringbuilderObject.ToString();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                cmd.ExecuteNonQuery();
                //Console.WriteLine("Query Executed");
            }
            return "Query Executed";


        }
    }
}
