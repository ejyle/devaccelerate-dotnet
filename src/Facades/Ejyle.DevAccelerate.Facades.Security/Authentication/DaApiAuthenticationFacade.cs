// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Tenants;
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

namespace Ejyle.DevAccelerate.Facades.Security.Authentication
{
    public class DaApiAuthenticationFacade : DaApiAuthenticationFacade<string, DaUser, UserManager<DaUser>, SignInManager<DaUser>, DaTenant, DaTenantUser, DaTenantAttribute, DaTenantManager, DaUserSession, DaUserSessionManager, DaAuthenticationResult>
    {
        public DaApiAuthenticationFacade(UserManager<DaUser> userManager, SignInManager<DaUser> signInManager, DaTenantManager tenantManager, DaUserSessionManager userSessionManager)
            : base(userManager, signInManager, tenantManager, userSessionManager)
        {
        }
    }

    public class DaApiAuthenticationFacade<TKey, TUser, TUserManager, TSignInManager, TTenant, TTenantUser, TTenantAttribute, TTenantManager, TUserSession, TUserSessionManager, TAuthenticationResult>
        : DaAuthenticationFacadeBase<TKey, TUser, TUserManager, TSignInManager, TTenant, TTenantUser, TTenantAttribute, TTenantManager, TUserSession, TUserSessionManager, TAuthenticationResult>
        where TKey : IEquatable<TKey>
        where TUser : DaUser<TKey>
        where TUserManager : UserManager<TUser>
        where TSignInManager : SignInManager<TUser>
        where TTenantManager : DaTenantManager<TKey, TTenant, TTenantUser>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute>, new()
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TTenant>, new()
        where TUserSession : DaUserSession<TKey>, new()
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
        where TAuthenticationResult : DaAuthenticationResult<TKey>, new()
    {
        public DaApiAuthenticationFacade(UserManager<TUser> userManager, SignInManager<TUser> signInManager, TTenantManager tenantManager, TUserSessionManager userSessionManager)
            : base(userManager, signInManager, tenantManager, userSessionManager)
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

        public async Task<DaAuthenticationResult<TKey>> GetOrCreateAccessToken(ClaimsPrincipal principal, string deviceAgent = null, string ipAddress = null, int? expiryTimeInMinutes = null)
        {
            var signedIn = SignInManager.IsSignedIn(principal);

            if (!signedIn)
            {
                return DaAuthenticationResult<TKey>.Failed;
            }

            var validationResult = await ValidateUserCredentialsAsync(principal.Identity.Name, null, false);

            if (!validationResult.Result.IsSuccess)
            {
                return validationResult.Result;
            }

            var userSession = await UserSessionManager.FindLatestByUserIdAsync(validationResult.User.Id);

            if (userSession == null)
            {
                await CreateUserSessionAsync(validationResult.User.Id, null, ipAddress, null, expiryTimeInMinutes);
            }

            return DaAuthenticationResult<TKey>.Success(userSession.AccessToken);
        }

        public async Task<bool> ValidateAccessToken(string accessToken)
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
    }
}