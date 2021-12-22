namespace ProjectP0
{
    public class Product
    {
        private int productId;
        private string? productName;
        private int storeId;
        private decimal productPrice;
        public int ProductId   // property
        {
            get { return productId; }   // get method
            set { productId = value; }  // set method
        }
        public string? ProductName   // property
        {
            get { return productName; }   // get method
            set { productName = value; }  // set method
        }

   
        public int StoreId   // property
        {
            get { return storeId; }   // get method
            set { storeId = value; }  // set method
        }
        
        public decimal ProductPrice   // property
        {
            get { return productPrice; }   // get method
            set { productPrice = value; }  // set method
        }

    }
}