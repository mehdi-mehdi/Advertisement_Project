using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Security.Model
{
    public class SecurityUserClaim : IdentityUserClaim<Guid>
    {
    }
}
