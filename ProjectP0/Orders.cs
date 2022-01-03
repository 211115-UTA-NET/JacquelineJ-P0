using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class Orders
    {
        private int order_Id;
        private int cust_Id; 
        private DateTime order_Time;

        public int Order_Id   // property
        {
            get { return order_Id; }   // get method
            set { order_Id = value; }  // set method
        }
        public int Cust_Id   // property
        {
            get { return cust_Id; }   // get method
            set { cust_Id = value; }  // set method
        }
        public DateTime Order_Time   // property
        {
            get { return order_Time; }   // get method
            set { order_Time = value; }  // set method
        }
    }
}
