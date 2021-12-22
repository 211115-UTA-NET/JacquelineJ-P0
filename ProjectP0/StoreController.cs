using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class StoreController
    {
        public void add()
        {

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();

            StringBuilder stringbuilderObject = new StringBuilder();
            stringbuilderObject.Append("INSERT INTO Store (StoreId,StoreName,S_Address,ZipCode) VALUES");
            //    stringbuilderObject.Append("(11012,'Jane','Potter'),");
            //  stringbuilderObject.Append("(11013,'Mat','Chip'),");
            stringbuilderObject.Append("(123,'Belmont ','Glastonbury',06064)");

            string sqlQuery = stringbuilderObject.ToString();

            Console.WriteLine("Inserting into Store table");
            objDB.Insert(sqlQuery, connectionObj);
            Console.WriteLine("Insert Complete...");

        }
        public void results()
        {
            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            List<Store> storeList = new List<Store>();

            string storeSelectQuery = "Select * from Store";
            Console.WriteLine("StoreController : results : Fetching from Store table" + storeSelectQuery);
            try
            {
                SqlDataReader reader = objDB.FetchProducts(storeSelectQuery, connectionObj);
                Store storeObj = null;

                using (reader)
                {
                    while (reader.Read())
                    {
                        storeObj = new Store();
                        storeObj.StoreId = reader.GetInt32(0);
                        storeObj.StoreName = reader.GetString(1);
                        storeObj.Store_Address = reader.GetString(2);
                        storeObj.Store_Zip = reader.GetInt32(3);
                        storeList.Add(storeObj);
                    }
           
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }
            foreach (Store item in storeList)
            {
                Console.WriteLine("Store-Id: " + item.StoreId + "  Store-Name: " + item.StoreName+ " Store-Address: " + item.Store_Address + " Zipcode :  " + item.Store_Zip);

            }
            Console.WriteLine("Fetch Complete...");

        }
    }
}
