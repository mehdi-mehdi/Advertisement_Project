using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Contracts;
using Core.Security.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;

namespace Core.Security
{
    public class SecurityUserManager : UserManager<SecurityUser, Guid>, ISecurityUserManager
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IIdentityMessageService _emailService;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IIdentityMessageService _smsService;
        private readonly IUserStore<SecurityUser, Guid> _store;
        public SecurityUserManager(IUserStore<SecurityUser, Guid> store, IApplicationRoleManager roleManager,
            IDataProtectionProvider dataProtectionProvider,
            IIdentityMessageService smsService,
            IIdentityMessageService emailService)
            : base(store)
        {
            _store = store;
            _roleManager = roleManager;
            _dataProtectionProvider = dataProtectionProvider;
            _smsService = smsService;
            _emailService = emailService;
            CreateApplicationUserManager();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(SecurityUser applicationSecurityUser)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await CreateIdentityAsync(applicationSecurityUser, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<bool> HasPassword(Guid userId)
        {
            var user = await FindByIdAsync(userId);
            return user != null && user.PasswordHash != null;
        }

        public async Task<bool> HasPhoneNumber(Guid userId)
        {
            var user = await FindByIdAsync(userId);
            return user != null && user.PhoneNumber != null;
        }

        public Func<CookieValidateIdentityContext, Task> OnValidateIdentity()
        {
            return SecurityStampValidator.OnValidateIdentity<SecurityUserManager, SecurityUser, Guid>(
                         validateInterval: TimeSpan.FromMinutes(30),
                         regenerateIdentityCallback: generateUserIdentityAsync,
                         getUserIdCallback: (id) => (Guid.Parse(id.GetUserId())));
        }

        private async Task<ClaimsIdentity> generateUserIdentityAsync(SecurityUserManager manager, SecurityUser applicationSecurityUser)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(applicationSecurityUser, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        private void CreateApplicationUserManager()
        {
            // Configure validation logic for usernames
            this.UserValidator = new UserValidator<SecurityUser, Guid>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            this.UserLockoutEnabledByDefault = true;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            this.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            this.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<SecurityUser, Guid>
            {
                MessageFormat = "Your security code is: {0}"
            });
            this.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<SecurityUser, Guid>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            this.EmailService = _emailService;
            this.SmsService = _smsService;

            if (_dataProtectionProvider != null)
            {
                var dataProtector = _dataProtectionProvider.Create("ASP.NET Identity");
                this.UserTokenProvider = new DataProtectorTokenProvider<SecurityUser, Guid>(dataProtector);
            }
        }

        public Task<IdentityResult> AddToRolesAsync(Guid userId, params string[] roles)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RemoveFromRolesAsync(Guid userId, params string[] roles)
        {
            throw new NotImplementedException();
        }

        public new Task<Guid> GetAccessFailedCountAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void SeedDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
