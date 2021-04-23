using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using wECommerce.Models.User;
using wECommerce.Models.UserManager;

namespace wECommerce.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> userManager;
        private IConfiguration configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<UserManagerResponse> LoginAsync(LoginUser userModel)
        {
            var user = await userManager.FindByEmailAsync(userModel.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "User not found with the given email address",
                    IsSuccesful = false
                };
            }

            var result = await userManager.CheckPasswordAsync(user, userModel.Password);

            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccesful = false
                };
            }

            var claims = new[]
            {
                new Claim("Email", userModel.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: configuration["AuthSettings:Issuer"],
                audience: configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccesful = true,
                ExpireDate = token.ValidTo
            };
                


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
