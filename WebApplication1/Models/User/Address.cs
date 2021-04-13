using System.ComponentModel.DataAnnotations;

namespace wECommerce.Models
{
    public class Address
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Customer ID is required")]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Is Billing Address is required")]
        public bool IsBillingAddress { get; set; }
    }
}