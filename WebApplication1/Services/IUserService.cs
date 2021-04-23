using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wECommerce.Models.User;
using wECommerce.Models.UserManager;

namespace wECommerce.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterUser user);

        Task<UserManagerResponse> LoginAsync(LoginUser user);
    }
}
