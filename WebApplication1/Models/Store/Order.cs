using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wECommerce.Models.Store
{
    public class Order
    {
        public long Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        [Required(ErrorMessage = "Customer ID is required")]
        public Customer Customer { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPayed { get; set; }

    }
}
