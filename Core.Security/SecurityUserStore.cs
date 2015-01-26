using System;
using System.Data.Entity;
using Core.FrameWork.Contract;
using Core.Security.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Security
{
    public class SecurityUserStore : UserStore<SecurityUser, SecurityRole, Guid, SecurityUserLogin, SecurityUserRole, SecurityUserClaim>
    {
        public SecurityUserStore(IUnitOfWork dbContext)
            : base(dbContext as DbContext)
        {

        }
   
    }

}
