using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class CustomerController : IInsertInTables
    {
        public void add()
        {
            
            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
                
            StringBuilder stringbuilderObject = new StringBuilder();
            Console.WriteLine("Enter Customer First Name,Last Name,Customer City and State ");
            
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string customer_City = Console.ReadLine();
            string customer_State = Console.ReadLine();
            
            stringbuilderObject.Append("INSERT INTO Customer (CustomerFirstName, CustomerLastName, C_Address1, C_Address2) VALUES ");
            stringbuilderObject.Append("('" + firstName + "',"+ "'" + lastName + "',"+ "'" + customer_City + "',"+ "'" + customer_State + "')");
            string sqlQuery = stringbuilderObject.ToString();
           // Console.WriteLine("Inserting into Customer table");
            objDB.Insert(sqlQuery, connectionObj);
            //Console.WriteLine("Insert Complete...");
        }
        
        public void results(string cusName)
        {
            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            List<Customer> customerList = new List<Customer>();

            string customerSelectQuery = "Select * from Customer";
            StringBuilder stringBuilderObj = new StringBuilder();
            stringBuilderObj.Append(customerSelectQuery);
            if (cusName != null && cusName.Length > 0)
            {
                stringBuilderObj.Append(" Where CustomerLastName = '" + cusName + "'");
            }
            string Query = stringBuilderObj.ToString();
            //Console.WriteLine("CustomerController : results : Fetching from Customer table" + Query);
            try
            {
                SqlDataReader reader = objDB.FetchProducts(Query, connectionObj);
                Customer customerObj = null;

                using (reader)
                {
                    while (reader.Read())
                    {
                        customerObj = new Customer();
                        customerObj.Customer_Id = reader.GetInt32(0);
                        customerObj.Customer_FirstName = reader.GetString(1);
                        customerObj.Customer_LastName = reader.GetString(2);
                        customerObj.Customer_City = reader.GetString(3);
                        customerObj.Customer_State = reader.GetString(4);
                        customerList.Add(customerObj);
                    }
                    //Console.WriteLine("Customer objects created :");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }
           foreach (Customer customer in customerList)
            {
                Console.WriteLine("Customer-Id: " + customer.Customer_Id + "  Customer_FirstName: " + customer.Customer_FirstName+ " Customer_LastName: "+customer.Customer_LastName+" Customer_City "+customer.Customer_City+ " Customer_City "+customer.Customer_State);

            }
            Console.WriteLine("Fetch Complete...");

        }
    }
}
