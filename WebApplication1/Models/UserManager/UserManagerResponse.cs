using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wECommerce.Models.User
{
    [NotMapped]
    public class UserManagerResponse
    {

        public string Message { get; set; }
        public bool IsSuccesful { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
