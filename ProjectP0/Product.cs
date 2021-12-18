namespace ProjectP0
{
    public class Product
    {
        public int  ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public Product()
        {
            ProductId = 0;
            ProductName = "product1";
            ProductPrice = 0.00M;
        }

        public Product(int proID,string proName, decimal proCost)
        {
            ProductId = proID;
            ProductName = proName;
            ProductPrice = proCost;
        }
    }
}