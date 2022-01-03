using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class OrderDetails
    {
        private int order_Id;
        private int cust_Id;
        private string cust_FName;
        private string cust_LName;
        private int prod_Id;
        private string prod_Name;
        public int prod_Quantity;
        private int store_Id;
        private string store_Name;
        private DateTime order_Time;

        public int Order_Id
        {
            get { return order_Id; }
            set { order_Id = value; }
      
        }

        public int Cust_ID
        {
            get { return cust_Id; }
            set { cust_Id = value; }
            
        }

        public string Cust_FName
        {
            get { return cust_FName; }
            set { cust_FName = value; }
        }

        public string Cust_LName
        {
            get { return cust_LName; }
            set { cust_LName = value; }
        }

        public int Prod_Id
        {
            get { return prod_Id; }
            set { prod_Id = value; }

        }

        public string Prod_Name
        {
            get { return prod_Name; }
            set { prod_Name = value; }
        }

        public int Prod_Quantity
        {
            get { return prod_Quantity; }
            set { prod_Quantity = value; }
        }

        public int Store_Id
        {
            get { return store_Id; }
            set { store_Id = value; }
        }

        public string Store_Name
        {
            get { return store_Name; }
            set { store_Name = value; }
        }
        public DateTime Order_Time   // property
        {
            get { return order_Time; }   // get method
            set { order_Time = value; }  // set method
        }
    }
}
