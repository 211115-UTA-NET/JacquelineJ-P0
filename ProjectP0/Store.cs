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
        public int StoreId   // property
        {
            get { return storeId; }   // get method
            set { storeId = value; }  // set method
        }
        private string? storeName;
        public string? StoreName   // property
        {
            get { return storeName; }   // get method
            set { storeName = value; }  // set method
        }
        private string? store_Address;
        public string? Store_Address  // property
        {
            get { return store_Address; }   // get method
            set { store_Address = value; }  // set method
        }
        private int store_Zip;
        public int Store_Zip   // property
        {
            get { return store_Zip; }   // get method
            set { store_Zip = value; }  // set method
        }

    }
}
