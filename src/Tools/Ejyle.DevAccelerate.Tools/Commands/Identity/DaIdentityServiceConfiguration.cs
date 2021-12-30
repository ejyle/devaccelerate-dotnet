using Ejyle.DevAccelerate.Identity.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Tools.Commands.Identity
{
    public class DaIdentityServiceConfiguration
    {
        public ServiceCollection CreateAndConfigureIdentity(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddDbContext<DaIdentityDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<DaUser, DaRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 6;
                opt.User.RequireUniqueEmail = true;
            })
            .AddRoles<DaRole>()
            .AddEntityFrameworkStores<DaIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddLogging(configure => {
                configure.AddConsole();
            });

            return services;
        }
    }
}
