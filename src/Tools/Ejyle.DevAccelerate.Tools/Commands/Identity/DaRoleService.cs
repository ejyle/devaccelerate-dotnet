using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Tools.Commands.Identity
{
    public interface IDaRoleService
    {
        IdentityResult AddToRoles(string userName, string[] roles);
    }

    public class DaRoleService : IDaRoleService
    {
        private readonly UserManager<DaUser> userManager;

        public DaRoleService(UserManager<DaUser> userManager)
        {
            this.userManager = userManager;
        }

        public IdentityResult AddToRoles(string userName, string[] roles)
        {
            var user = DaAsyncHelper.RunSync<DaUser>(() => this.userManager.FindByNameAsync(userName));

            if (user == null)
            {
                throw new Exception($"Username {userName} doesn't exist.");
            }

            return DaAsyncHelper.RunSync<IdentityResult>(() => this.userManager.AddToRolesAsync(user, roles));
        }
    }
}
