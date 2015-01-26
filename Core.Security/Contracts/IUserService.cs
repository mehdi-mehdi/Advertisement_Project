using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.FrameWork.Contract;
using Core.Security.Model;
using Microsoft.AspNet.Identity;

namespace Core.Security.Contracts
{
    public interface IUserService : IServiceContract
    {
        Task<IdentityResult> CreateAsync(SecurityUser securityUser, string password);
        IdentityResult Create(SecurityUser securityUser, string password);
        Task<IdentityResult> DeleteUserAsync(SecurityUser securityUser);
        IdentityResult DeleteUser(SecurityUser securityUser);
        SecurityUser FindByName(string userName);
        Task<IdentityResult> UpdateAsync(SecurityUser securityUser);
        IdentityResult Update(SecurityUser securityUser);
        IList<string> GetRoles(Guid userId);
    }
}
