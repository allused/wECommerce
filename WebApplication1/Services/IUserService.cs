using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wECommerce.Models.User;

namespace wECommerce.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterUser user);

    }
}
