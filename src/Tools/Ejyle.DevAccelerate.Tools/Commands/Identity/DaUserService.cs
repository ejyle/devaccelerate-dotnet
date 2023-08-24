using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity;
using Ejyle.DevAccelerate.Identity.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Tools.Commands.Identity
{
    public interface IDaUserService
    {
        IdentityResult Create(string userName, string email, string password);
        DaUser GetUser(string userName);
        DaUser GetSystemUser();
    }

    public class DaUserService : IDaUserService
    {
        private readonly UserManager<DaUser> userManager;

        public DaUserService(UserManager<DaUser> userManager)
        {
            this.userManager = userManager;
        }

        public IdentityResult Create(string userName, string email, string password)
        {
            var user = DaAsyncHelper.RunSync<DaUser>(() => this.userManager.FindByNameAsync(userName));

            if (user != null)
            {
                throw new Exception($"Username {userName} already exists.");
            }

            user = DaAsyncHelper.RunSync<DaUser>(() => this.userManager.FindByEmailAsync(email));

            if (user != null)
            {
                throw new Exception($"Email address {email} already exists.");
            }

            user = new DaUser { UserName = userName, Email = email, EmailConfirmed = true, Status = DaAccountStatus.Active };
            return DaAsyncHelper.RunSync<IdentityResult>(() => this.userManager.CreateAsync(user, password));
        }

        public DaUser GetUser(string userName)
        {
            return DaAsyncHelper.RunSync<DaUser>(() => this.userManager.FindByNameAsync(userName));
        }

        public DaUser GetSystemUser()
        {
            return DaAsyncHelper.RunSync<DaUser>(() => this.userManager.FindByNameAsync("System"));
        }
    }
}
