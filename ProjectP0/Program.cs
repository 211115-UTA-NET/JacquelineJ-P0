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
            Console.WriteLine("Below are the actions list :");
            Console.WriteLine("1.Add a Customer  ");
            Console.WriteLine("2.Select a customer by name");
            Console.WriteLine("3.Display all the customers");
            Console.WriteLine("4.Display list of Products");
            Console.WriteLine("5.Display list of Stores");
            Console.WriteLine("6.Add an Order");
            Console.WriteLine("7.Display all orders ");
            Console.WriteLine("8.Select order details by order_Id ");
            Console.WriteLine("9.Exit");
            Console.WriteLine("Please enter action you want to perform: ");
            int actionNum = Convert.ToInt32(Console.ReadLine());

            CustomerController customerControllerObj = new CustomerController();
            ProductController productControllerObj = new ProductController();
            StoreController storeControllerObj = new StoreController();
            OrderController orderControllerObj = new OrderController();

            switch (actionNum)
            {
                case 1:
                    Console.WriteLine("Calling Customer Add...");

                    customerControllerObj.add();
                    break;
                case 2:
                    Console.WriteLine("Fetching a customer details...");
                    Console.WriteLine("Enter Customer Name : ");
                    string c_Name = Console.ReadLine();
                    customerControllerObj.results(c_Name);
                    break;
                case 3:
                    Console.WriteLine("Fetching a customer details...");
                    customerControllerObj.results(null);
                    break;
                case 4:
                    Console.WriteLine("Fecting products...");
                    productControllerObj.results_Pro();
                    break;
                case 5:
                    Console.WriteLine("Fetch Store details...");
                    storeControllerObj.results();
                    break;
                case 6:
                    Console.WriteLine("Adding an Order...");
                    orderControllerObj.add();
                    break;
                case 7:
                    Console.WriteLine("Fetch all orders.. ");
                    orderControllerObj.getOrders(null);
                    break;
                case 8:
                    Console.WriteLine("Fetch order for orderId.. ");
                    Console.WriteLine("Enter OrderID : ");
                    string orderId = Console.ReadLine();
                    orderControllerObj.getOrders(orderId);
                    break;
                case 9:
                    return;

            }


            Console.ReadKey();
        }
    }
}
