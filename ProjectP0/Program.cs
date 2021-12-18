using System;

namespace ProjectP0
{
    public class Program
    {
       public static void Main(string[] args)
        {
            // Customer customerObj = new Customer();
            // Console.WriteLine("Enter Customer First Name :");
            //customerObj.CustomerFirstName = Console.ReadLine();
            // Console.WriteLine("Enter Customer Last Name : ");
            // customerObj.CustomerLastName = Console.ReadLine();
            // Console.WriteLine($"Given Customer First and Last Names are : {customerObj.CustomerFirstName} {customerObj.CustomerLastName} ");

            SqlConnectionApp sqlConnectionObject = new SqlConnectionApp();
            Console.WriteLine(sqlConnectionObject.DatabaseConn());


            StoreClass storeObj = new StoreClass();
            Console.WriteLine($"You picked store locted in : {storeObj.StoreLocations()}");

            Product productObj = new Product(1003,"Cheese",30.00M);
            Product productObj2 = new Product(1002,"Butter",25.00M);

            Console.WriteLine($"Product : {productObj2.ProductName}\n Product ID: {productObj2.ProductId} \n Product Cost : {productObj2.ProductPrice}");
           
            Console.WriteLine($"Product : {productObj.ProductName}\n Product ID: {productObj.ProductId}\n Product Cost : {productObj.ProductPrice}");
            
            storeObj.ProductList.Add(productObj);
            storeObj.ProductList.Add(productObj2);

            decimal totalprice = storeObj.CheckOut();
            Console.WriteLine($"Total Cost : {totalprice}");


            Console.ReadKey();
      
        }
    }
}