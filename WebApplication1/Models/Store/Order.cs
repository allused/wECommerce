using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wECommerce.Models.Store
{
    public class Order
    {
        public long Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
