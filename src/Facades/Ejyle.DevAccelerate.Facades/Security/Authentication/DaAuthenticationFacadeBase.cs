// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Ejyle.DevAccelerate.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Ejyle.DevAccelerate.MultiTenancy.Tenants;

namespace Ejyle.DevAccelerate.Facades.Security.Authentication
{
    public abstract class DaAuthenticationFacadeBase<TKey, TUser, TUserManager, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TTenantManager, TUserSession, TUserSessionManager, TAuthenticationResult>
        where TKey : IEquatable<TKey>
        where TUser : DaUser<TKey>
        where TUserManager : UserManager<TUser>
        where TTenantManager : DaTenantManager<TKey, TTenant, TTenantUser>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute>, new()
        where TMTPTenant : DaMTPTenant<TKey>
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TTenant>, new()
        where TUserSession : DaUserSession<TKey>, new()
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
        where TAuthenticationResult : DaAuthenticationResult<TKey>, new()
    {
        public DaAuthenticationFacadeBase(UserManager<TUser> userManager, TTenantManager tenantManager, TUserSessionManager userSessionManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            TenantManager = tenantManager ?? throw new ArgumentNullException(nameof(tenantManager));
            UserSessionManager = userSessionManager ?? throw new ArgumentNullException(nameof(userSessionManager));
        }

        protected UserManager<TUser> UserManager
        {
            get;
            private set;
        }

        protected TTenantManager TenantManager
        {
            get;
            private set;
        }

        protected TUserSessionManager UserSessionManager
        {
            get;
            private set;
        }

       protected async Task<TUserSession> CreateUserSessionAsync(TKey userId, string systemSessionId, string ipAddress, string deviceAgent, int? expiryTimeInMinutes = null)
        {
            var userSession = new TUserSession()
            {
                UserId = userId,
                AccessToken = Guid.NewGuid().ToString(),
                SystemSessionId = systemSessionId,
                IpAddress = ipAddress,
                DeviceAgent = deviceAgent,
                Status = DaUserSessionStatus.Active,
                CreatedDateUtc = DateTime.UtcNow,
                ExpiryDateUtc = null,
                ExpiredDateUtc = null
            };

            await UserSessionManager.CreateAsync(userSession);
            return userSession;
        }

        protected async Task<DaUserValidationResult> ValidateUserCredentialsAsync(string userName, string password = null, bool validatePassword = true)
        {
            var user = await UserManager.FindByNameAsync(userName);

            if (user == null)
            {
                return new DaUserValidationResult(DaAuthenticationResult<TKey>.Failed, null, null);
            }

            if (validatePassword)
            {
                var validPassword = await UserManager.CheckPasswordAsync(user, password);

                if (!validPassword)
                {
                    return new DaUserValidationResult(DaAuthenticationResult<TKey>.Failed, null, null);
                }
            }

            if (user.IsDeleted)
            {
                return new DaUserValidationResult(DaAuthenticationResult<TKey>.Deleted, null, null);
            }

            if (user.Status != DaAccountStatus.Active)
            {
                if (user.Status == DaAccountStatus.Inactive)
                {
                    return new DaUserValidationResult(DaAuthenticationResult<TKey>.NotActive, null, null);
                }
                else if (user.Status == DaAccountStatus.Suspended)
                {
                    return new DaUserValidationResult(DaAuthenticationResult<TKey>.Suspended, null, null);
                }
                else if (user.Status == DaAccountStatus.Closed)
                {
                    return new DaUserValidationResult(DaAuthenticationResult<TKey>.Closed, null, null);
                }
            }

            var tenants = await TenantManager.FindByUserIdAsync(user.Id);
            List<TKey> tenantKeys = null;

            if (tenants != null && tenants.Count > 0)
            {
                if (tenants.Count == 1)
                {
                    if (tenants[0].Status != DaTenantStatus.Active)
                    {
                        return new DaUserValidationResult(DaAuthenticationResult<TKey>.TenantNotActive, null, null);
                    }
                    else
                    {
                        tenantKeys = new List<TKey>()
                        {
                            tenants[0].Id
                        };
                    }
                }
                else
                {
                    tenantKeys = new List<TKey>();
                    foreach (var tenant in tenants)
                    {
                        if (tenant.Status == DaTenantStatus.Active)
                        {
                            tenantKeys.Add(tenant.Id);
                        }
                    }

                    if (tenantKeys.Count <= 0)
                    {
                        return new DaUserValidationResult(DaAuthenticationResult<TKey>.TenantNotActive, null, null);
                    }
                }
            }

            return new DaUserValidationResult(DaAuthenticationResult<TKey>.Success(), user, tenantKeys);
        }

        protected class DaUserValidationResult
        {
            TUser _user = null;
            List<TKey> _tenantKeys = null;
            DaAuthenticationResult<TKey> _result;

            public DaUserValidationResult(DaAuthenticationResult<TKey> result, TUser user, List<TKey> tenantKeys) : base()
            {
                _user = user;
                _result = result;
                _tenantKeys = tenantKeys;
            }

            public TUser User
            {
                get
                {
                    return _user;
                }
            }

            public List<TKey> TenantKeys
            {
                get
                {
                    return _tenantKeys;
                }
            }

            public DaAuthenticationResult<TKey> Result
            {
                get
                {
                    return _result;
                }
            }
        }
    }
}