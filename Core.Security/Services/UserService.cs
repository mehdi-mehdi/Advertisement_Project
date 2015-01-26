using System;
using System.Collections.Generic;
using Core.FrameWork.Base;
using Core.FrameWork.Contract;
using Core.Security.Contracts;
using Core.Security.Model;
using Microsoft.AspNet.Identity;

namespace Core.Security.Services
{
    public partial class UserService : ServiceBase<SecurityUser>, IUserService
    {
        private readonly Lazy<SecurityUserManager> _userManager;

        public UserService(IUnitOfWork uow)
            : base(uow)
        {
            _userManager = new Lazy<SecurityUserManager>(() => new SecurityUserManager(new SecurityUserStore(uow)));
        }

        public IdentityResult Create(SecurityUser securityUser, string password)
        {
            try
            {
                var Result= _userManager.Value.Create(securityUser, password);
                return Result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public IdentityResult DeleteUser(SecurityUser securityUser)
        {
            return _userManager.Value.Delete(securityUser);
        }

        public SecurityUser FindByName(string userName)
        {
            var user= _userManager.Value.FindByName(userName);           
            return user;
        }

        public IdentityResult Update(SecurityUser securityUser)
        {
            return _userManager.Value.Update(securityUser);
        }

        public IList<string> GetRoles(Guid userId)
        {
            return _userManager.Value.GetRoles(userId);
        }
    }
}
