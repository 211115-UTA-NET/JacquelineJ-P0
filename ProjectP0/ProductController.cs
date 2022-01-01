using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectP0
{
    public class ProductController : IInsertInTables
    {
        public void add()
        {

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();

            StringBuilder stringbuilderObject = new StringBuilder();
            stringbuilderObject.Append("INSERT INTO Product (ProductID,ProductName,StoreId,ProductPrice) VALUES");
            stringbuilderObject.Append("(6,'Cheese',122,20)");
            string sqlQuery = stringbuilderObject.ToString();
            //Console.WriteLine("Inserting into Customer table");
            objDB.Insert(sqlQuery, connectionObj);
            Console.WriteLine("Insert Complete...");
        }
        
        public void results_Pro()
        {
            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            List<Product> productList = new List<Product>();

            string productSelectQuery = "Select * from Product";
            //Console.WriteLine("ProductController : results : Fetching from Product table"+ productSelectQuery);
            try {
                SqlDataReader reader = objDB.FetchProducts(productSelectQuery, connectionObj);
                Product productObj = null;

                using (reader)
                {
                    while (reader.Read())
                    {
                        productObj = new Product();
                        productObj.ProductId = reader.GetInt32(0);
                        productObj.ProductName = reader.GetString(1);
                        productObj.StoreId = reader.GetInt32(2);
                        productObj.ProductPrice = reader.GetDecimal(3);
                        productList.Add(productObj);
                    }
                    //Console.WriteLine("Product objects created :");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }

            foreach (Product item in productList)
            {
                Console.WriteLine("Product-Id: " + item.ProductId + "\tProduct-Name: " + item.ProductName + " Pro-StoreId :" + item.StoreId+"\tProduct-Price : " + item.ProductPrice); ;

            }
           // Console.WriteLine("Fetch Complete...");
            
        }
    }
}


