// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.Identity.EF.UserSessions;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Ejyle.DevAccelerate.Identity;
using Ejyle.DevAccelerate.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using Ejyle.DevAccelerate.MultiTenancy.Tenants;
using Ejyle.DevAccelerate.MultiTenancy.EF.Tenants;

namespace Ejyle.DevAccelerate.Facades.Security.Authentication
{
    public class DaApiAuthenticationFacade : DaApiAuthenticationFacade<string, DaUser, UserManager<DaUser>, DaTenant, DaTenantUser, DaTenantAttribute, DaMTPTenant, DaTenantDomain, DaTenantManager, DaUserSession, DaUserSessionManager, DaAuthenticationResult>
    {
        public DaApiAuthenticationFacade(UserManager<DaUser> userManager, DaTenantManager tenantManager, DaUserSessionManager userSessionManager)
            : base(userManager, tenantManager, userSessionManager)
        {
        }
    }

    public class DaApiAuthenticationFacade<TKey, TUser, TUserManager, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TTenantDomain, TTenantManager, TUserSession, TUserSessionManager, TAuthenticationResult>
        : DaAuthenticationFacadeBase<TKey, TUser, TUserManager, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TTenantDomain, TTenantManager, TUserSession, TUserSessionManager, TAuthenticationResult>
        where TKey : IEquatable<TKey>
        where TUser : DaUser<TKey>
        where TUserManager : UserManager<TUser>
        where TTenantManager : DaTenantManager<TKey, TTenant, TTenantUser, TMTPTenant>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute, TMTPTenant, TTenantDomain>, new()
        where TTenantDomain : DaTenantDomain<TKey, TTenant>
        where TMTPTenant : DaMTPTenant<TKey, TTenant>
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TTenant>, new()
        where TUserSession : DaUserSession<TKey>, new()
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
        where TAuthenticationResult : DaAuthenticationResult<TKey>, new()
    {
        public DaApiAuthenticationFacade(UserManager<TUser> userManager, TTenantManager tenantManager, TUserSessionManager userSessionManager)
            : base(userManager, tenantManager, userSessionManager)
        { }

        public DaAuthenticationResult<TKey> CreateAccessToken(string userName, string password, string ipAddress, string deviceAgent, int? expiryTimeInMinutes = null)
        {
            return DaAsyncHelper.RunSync<DaAuthenticationResult<TKey>>(() => CreateAccessTokenAsync(userName, password, ipAddress, deviceAgent, expiryTimeInMinutes));
        }

        public virtual async Task<DaAuthenticationResult<TKey>> CreateAccessTokenAsync(string userName, string password, string ipAddress, string deviceAgent, int? expiryTimeInMinutes = null)
        {
            if (expiryTimeInMinutes <= 0)
            {
                throw new InvalidOperationException("expiryTimeInMinutes must be greater than 0.");
            }

            var validationResult = await ValidateUserCredentialsAsync(userName, password, true);

            if (!validationResult.Result.IsSuccess)
            {
                return validationResult.Result;
            }

            var userSession = new TUserSession()
            {
                UserId = validationResult.User.Id,
                AccessToken = Guid.NewGuid().ToString(),
                SystemSessionId = null,
                IpAddress = ipAddress,
                DeviceAgent = deviceAgent,
                Status = DaUserSessionStatus.Active,
                CreatedDateUtc = DateTime.UtcNow,
                ExpiryDateUtc = null,
                ExpiredDateUtc = null
            };

            if (expiryTimeInMinutes != null)
            {
                userSession.ExpiryDateUtc = DateTime.UtcNow.AddMinutes((int)expiryTimeInMinutes);
            }

            await UserSessionManager.CreateAsync(userSession);

            var tenantKeys = validationResult.TenantKeys;

            if (tenantKeys != null && tenantKeys.Count > 0)
            {
                return DaAuthenticationResult<TKey>.Success(userSession.AccessToken, tenantKeys);
            }
            else
            {
                return DaAuthenticationResult<TKey>.Success(userSession.AccessToken);
            }
        }

        public async Task<bool> ValidateAccessTokenAsync(string accessToken)
        {
            var userSession = await UserSessionManager.FindByAccessTokenAsync(accessToken);

            if (userSession == null)
            {
                return false;
            }

            if (userSession.Status != DaUserSessionStatus.Active)
            {
                return false;
            }

            if (userSession.ExpiredDateUtc != null)
            {
                return false;
            }

            var user = await UserManager.FindByIdAsync(userSession.UserId.ToString());

            if (user == null)
            {
                return false;
            }

            var validationResult = await ValidateUserCredentialsAsync(user.UserName, null, false);

            if(!validationResult.Result.IsSuccess)
            {
                return false;
            }

            if (userSession.ExpiryDateUtc != null)
            {
                if (DateTime.UtcNow > userSession.ExpiryDateUtc)
                {
                    userSession.Status = DaUserSessionStatus.Expired;
                    await UserSessionManager.UpdateStatusAsync(userSession.Id, DaUserSessionStatus.Expired);

                    return false;
                }
            }

            return true;
        }

        public bool ValidateAccessToken(string accessToken)
        {
            return DaAsyncHelper.RunSync<bool>(() => ValidateAccessTokenAsync(accessToken));
        }
    }
}