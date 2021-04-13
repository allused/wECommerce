using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Category
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Category name required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
