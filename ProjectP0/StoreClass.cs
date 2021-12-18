using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    internal class StoreClass
    {
        public List<Product> ProductList { get; set; }
        public List<Product> ShoppingCart { get; set; }
        Dictionary<string,string> Cities = new Dictionary<string, string>();
        public string? selectedStore { get; set; }

        public StoreClass()
        {
            ProductList = new List<Product>();
            ShoppingCart = new List<Product>();

        }
        public string StoreLocations()
        {
            Cities.Add("06026", "Granby Bushy Hill Farm");
            Cities.Add("06070", "Simsbury The Brewery at Maple View Farm");
            Cities.Add("06089", "Avon Robbs Farm");
            Cities.Add("06033", "Glastonbury Belmont Farm");
            Cities.Add("06032", "Farmington Rose's Berry Farm");
            Cities.Add("06105", "West Hartford Walnut Ledge Farm");

            Console.WriteLine("Hi! Below are the list of our Stores in different Locations. You can order from any of our Stores. ");
            Console.WriteLine("PLEASE PICK A STORE!!");
            foreach (KeyValuePair<string, string> items in Cities)
            {
                Console.WriteLine(items.Key,items.Value);
            }

            selectedStore = Console.ReadLine();
            if (selectedStore != null)
            {
                return selectedStore;


            }
            else
                Console.WriteLine("Enter a valid zipcode or Shope name from given options ");

            return "";
        }
        public decimal CheckOut()
        {
            decimal totalCost = 0;
            foreach (var item in ProductList)
            {
                totalCost = totalCost + item.ProductPrice;
            }
            ShoppingCart.Clear();

            return totalCost;
        }
         
    }   
}



