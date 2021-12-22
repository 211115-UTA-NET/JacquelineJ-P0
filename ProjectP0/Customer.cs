using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class Customer
    {
        private int customer_Id;
        private string? customer_FirstName;
        private string? customer_LastName;
        private string? customer_City;
        private string? customer_State;

        public int Customer_Id   // property
        {
            get { return customer_Id; }   // get method
            set { customer_Id = value; }  // set method
        }
        public string? Customer_FirstName   // property
        {
            get { return customer_FirstName; }   // get method
            set { customer_FirstName = value; }  // set method
        }
        public string? Customer_LastName   // property
        {
            get { return customer_LastName; }   // get method
            set { customer_LastName = value; }  // set method
        }
        public string? Customer_City   // property
        {
            get { return customer_City; }   // get method
            set { customer_City = value; }  // set method
        }
        public string? Customer_State   // property
        {
            get { return customer_State; }   // get method
            set { customer_State = value; }  // set method
        }

    }
}

