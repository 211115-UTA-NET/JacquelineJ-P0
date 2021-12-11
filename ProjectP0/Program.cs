using System;

namespace ProjectP0
{
    public class Program
    {
       public static void Main(string[] args)
        {
            Customer customerObj = new Customer();
            Console.WriteLine("Enter Customer First Name :");
            customerObj.CustomerFirstName = Console.ReadLine();
            Console.WriteLine("Enter Customer Last Name : ");
            customerObj.CustomerLastName = Console.ReadLine();
            Console.WriteLine($"Given Customer First and Last Names are : {customerObj.CustomerFirstName} {customerObj.CustomerLastName} ");
            Console.ReadKey();
      
        }
    }
}