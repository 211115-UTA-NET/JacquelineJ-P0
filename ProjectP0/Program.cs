using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace ProjectP0
{
    public class Program
    {
       public static void Main(string[] args)
        {
            SqlConnectionApp sqlConnectionAppObject = new SqlConnectionApp();
          
            sqlConnectionAppObject.DBConnection(sqlConnectionAppObject.sqlProperties());

            /*Customer customerObj = new Customer();

            Store storeObj = new Store();
            Orders ordersObj = new Orders();
            Product productObj = new Product();             

            //Console.WriteLine("Inserting into Customer table");
            SqlConnectionApp objDB = new SqlConnectionApp();
            //Console.WriteLine(objDB.Insert());
            //Console.WriteLine("Insert Complete...");

            QueryBuilder queryBuilderobj = new QueryBuilder();
           
            Console.WriteLine("Fetching from Customer table"); 
            Console.WriteLine(objDB.Fetch(queryBuilderobj.query()));
            Console.WriteLine("Fetch Complete...");*/

            Console.ReadKey();      
        }


        

    }
}