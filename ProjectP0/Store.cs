using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class Store
    {
        private int StoreId { get; set; }
        private string StoreName { get; set; }
        private string Store_Address { get; set; }
        private int Store_Zip { get; set; }

        public Store()
        {
            StoreId = 0;
            StoreName = "Null";
            Store_Address = "Null";
            Store_Zip = 0;
        }

        public Store(int str_Id,string str_Name, string str_add,int str_zipcode)
        {
            StoreId = str_Id;
            StoreName = str_Name;
            Store_Address = str_add;
            Store_Zip = str_zipcode;
        }
    }
}
