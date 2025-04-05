using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.Application.Contracts
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(string username, string email, string password);

        public Task<bool> LoginAsync(string username, string password);
    }
}
