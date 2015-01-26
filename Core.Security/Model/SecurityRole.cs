using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Security.Model
{
    public class SecurityRole : IdentityRole<Guid, SecurityUserRole>
    {
    }
}
