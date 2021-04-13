using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Title is required for a new product")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Category is required for a new product")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Price is required for a new product")]
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsOnSale { get; set; }
        [Required(ErrorMessage = "Short description is required for a new product")]
        [MaxLength(50)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Title is required for a new product")]
        [MaxLength(150)]
        public string LongDescription { get; set; }
        [Required(ErrorMessage = "Article number is required for a new product")]
        public long ArticleNumber { get; set; }
        public List<Picture> Pictures { get; set; }
        [Required(ErrorMessage = "Upload date is required for a new product")]
        public DateTime UploadDate { get; set; }
        public bool InStock { get; set; }
    }
}
