using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Security.Model
{
    public class SecurityUser : IdentityUser<Guid, SecurityUserLogin, SecurityUserRole, SecurityUserClaim>
    {
        public SecurityUser()
        {
            Id = Guid.NewGuid();
        }
    }
  
}
