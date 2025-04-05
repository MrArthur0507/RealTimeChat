using Microsoft.AspNetCore.Identity;
using RealTimeChat.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.Infrastructure.Implementations.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthService(UserManager<IdentityUser> userManager) {
            _userManager = userManager;
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null || ! await _userManager.CheckPasswordAsync(user, password))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }
    }
}
