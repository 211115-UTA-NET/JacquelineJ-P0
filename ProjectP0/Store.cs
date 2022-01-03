using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class Store
    {
        private int storeId;
        private string? storeName;
        private string? store_Address;
        private int store_Zip;

        public int StoreId   // property
        {
            get { return storeId; }   // get method
            set { storeId = value; }  // set method
        }
       public string? StoreName   // property
        {
            get { return storeName; }   // get method
            set { storeName = value; }  // set method
        }
       public string? Store_Address  // property
        {
            get { return store_Address; }   // get method
            set { store_Address = value; }  // set method
        }
       public int Store_Zip   // property
        {
            get { return store_Zip; }   // get method
            set { store_Zip = value; }  // set method
        }

    }
}

