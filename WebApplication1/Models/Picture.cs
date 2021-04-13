using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Picture
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Picture ID is required")]
        public string ImageId { get; set; }
        [Required(ErrorMessage = "You have to choose if it's a thumbnail")]
        public bool IsThumbNail { get; set; }
    }
}
