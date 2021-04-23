using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wECommerce.Models.User;

namespace wECommerce.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterUser user)
        {

            if (user == null)
            {
                throw new NullReferenceException("Register User Model is null");
            }
            if (user.Password != user.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    Message = "Confirmation password doesn't match the password",
                    IsSuccesful = false
                };
            }
            var identityUser = new IdentityUser
            {
                Email = user.Email,
                UserName = user.Email
            };

            var result = await userManager.CreateAsync(identityUser, user.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "Register succesful",
                    IsSuccesful = true
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccesful = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}
