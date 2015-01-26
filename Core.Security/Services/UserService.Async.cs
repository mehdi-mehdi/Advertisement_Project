using System.Threading.Tasks;
using Core.Security.Model;
using Microsoft.AspNet.Identity;

namespace Core.Security.Services
{
    public partial class UserService
    {
        public Task<IdentityResult> CreateAsync(SecurityUser securityUser, string password)
        {

            return _userManager.Value.CreateAsync(securityUser, password);
        }

        public Task<IdentityResult> DeleteUserAsync(SecurityUser securityUser)
        {
            return _userManager.Value.DeleteAsync(securityUser);
        }

        public Task<IdentityResult> UpdateAsync(SecurityUser securityUser)
        {
            return _userManager.Value.UpdateAsync(securityUser);
        }
    }
}
