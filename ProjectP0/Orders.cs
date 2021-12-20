using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class Orders
    {
        private int OrderId { get; set; }
        private int CustomerId { get; set; }
        private int ProductId { get; set; }
        private int Quantity { get; set; }

        public Orders()
        {
            OrderId = 0;
            CustomerId = 0;
            ProductId = 0;
            Quantity = 0;
        }
        public Orders(int or_Id,int c_Id,int pro_Id,int quan)
        {
            OrderId = or_Id;
            CustomerId = c_Id;
            ProductId = pro_Id;
            Quantity = quan;
        }
    }
}
