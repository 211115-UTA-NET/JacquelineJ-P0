using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class StoreController : IInsertInTables
    {
        public void addOrderNew()
        {

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();

            StringBuilder stringbuilderObject = new StringBuilder();
            stringbuilderObject.Append("INSERT INTO Store (StoreId,StoreName,S_Address,ZipCode) VALUES");
            stringbuilderObject.Append("(124,'Bushnell ','Glastonbury',06064)");
            string sqlQuery = stringbuilderObject.ToString();
            //Console.WriteLine("Inserting into Store table");
            objDB.Insert(sqlQuery, connectionObj);
            //Console.WriteLine("Insert Complete...");

        }
        public void results()
        {
            List<Store> storeList = getStores();
            foreach (Store item in storeList)
            {
                Console.WriteLine("Store-Id: " + item.StoreId + "  Store-Name: " + item.StoreName+ " Store-Address: " + item.Store_Address + " Zipcode :  " + item.Store_Zip);

            }
            Console.WriteLine("Fetch Complete...");

        }

        public List<Store> getStores()
        {
            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            string sqlQuery;
            StringBuilder stringbuilderObject = new StringBuilder();

            List<Store> storeList = new List<Store>();
            using (connectionObj)
            {
                // Query to be executed
                string queryString = "SELECT DISTINCT(S.STOREID) ,S.StoreName FROM STORE AS S,Product AS P   WHERE P.StoreId = S.StoreId ";
                SqlCommand command = new SqlCommand(queryString, connectionObj);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Store storeObj;
                    while (reader.Read())
                    {
                        storeObj = new Store();
                        storeObj.StoreId = reader.GetInt32(0);
                        storeObj.StoreName = reader.GetString(1);
                        storeList.Add(storeObj);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Query Not Executed : " + ex.Message);
                }
                finally { connectionObj.Close(); }

                return storeList;
            }
        }
    }
}
