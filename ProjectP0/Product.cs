namespace ProjectP0
{
    public class Product
    {
        private int  ProductId { get; set; }
        public string? ProductName { get; set; }
        private int StoreId { get; set; }
        public decimal ProductPrice { get; set; }

        public Product()
        {
            ProductId = 0;
            ProductName = "product1";
            StoreId = 0;
            ProductPrice = 0.00M;
        }

        public Product(int proID,string proName,int store_Id, decimal proCost)
        {
            ProductId = proID;
            ProductName = proName;
            StoreId=store_Id;
            ProductPrice = proCost;
        }
    }
}