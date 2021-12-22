using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class Orders
    {
        private int orderID;
        private int customerId; 
        private int productId; 
        private int quantity; 
        private DateTime orderTime;

        public int OrderID   // property
        {
            get { return orderID; }   // get method
            set { orderID = value; }  // set method
        }
        public int CustomerId   // property
        {
            get { return customerId; }   // get method
            set { customerId = value; }  // set method
        }
        public int ProductId   // property
        {
            get { return productId; }   // get method
            set { productId = value; }  // set method
        }
        public int Quantity   // property
        {
            get { return quantity; }   // get method
            set { quantity = value; }  // set method
        }
        public DateTime OrderTime   // property
        {
            get { return orderTime; }   // get method
            set { orderTime = value; }  // set method
        }
    }
}
