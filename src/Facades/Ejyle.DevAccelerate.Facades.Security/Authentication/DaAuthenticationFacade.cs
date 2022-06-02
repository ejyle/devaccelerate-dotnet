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

namespace Ejyle.DevAccelerate.Facades.Security.Authentication
{
    public class DaAuthenticationFacade : DaAuthenticationFacade<int, int?, DaUser, UserManager<DaUser>, SignInManager<DaUser>, DaTenant, DaTenantUser, DaTenantAttribute, DaTenantManager, DaUserSession, DaUserSessionManager, DaAuthenticationResult>
    {
        public DaAuthenticationFacade(UserManager<DaUser> userManager, SignInManager<DaUser> signInManager, DaTenantManager tenantManager, DaUserSessionManager userSessionManager)
            : base(userManager, signInManager, tenantManager, userSessionManager)
        {
        }
    }

    public class DaAuthenticationFacade<TKey, TNullableKey, TUser, TUserManager, TSignInManager, TTenant, TTenantUser, TTenantAttribute, TTenantManager, TUserSession, TUserSessionManager, TAuthenticationResult>
        where TKey : IEquatable<TKey>
        where TUser : DaUser<TKey, TNullableKey>
        where TUserManager : UserManager<TUser>
        where TSignInManager : SignInManager<TUser>
        where TTenantManager : DaTenantManager<TKey, TNullableKey, TTenant>
        where TTenant : DaTenant<TKey, TNullableKey, TTenantUser, TTenantAttribute>, new()
        where TTenantAttribute : DaTenantAttribute<TKey, TNullableKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TNullableKey, TTenant>, new()
        where TUserSession : DaUserSession<TKey>, new()
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
        where TAuthenticationResult : DaAuthenticationResult<TKey>
    {
        private const string USER_SESSION_KEY_SESSION_NAME = "DaAuthenticationFacade_SessionKey";

        public DaAuthenticationFacade(UserManager<TUser> userManager, SignInManager<TUser> signInManager, TTenantManager tenantManager, TUserSessionManager userSessionManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            TenantManager = tenantManager ?? throw new ArgumentNullException(nameof(tenantManager));
            SignInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            UserSessionManager = userSessionManager ?? throw new ArgumentNullException(nameof(userSessionManager));
        }

        public UserManager<TUser> UserManager
        {
            get;
            private set;
        }

        public TTenantManager TenantManager
        {
            get;
            private set;
        }

        public SignInManager<TUser> SignInManager
        {
            get;
            private set;
        }

        public TUserSessionManager UserSessionManager
        {
            get;
            private set;
        }

        public TAuthenticationResult Authenticate(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            return DaAsyncHelper.RunSync<TAuthenticationResult>(() => AuthenticateAsync(request, session, connection, credentials, expiryTimeInMinutes));
        }

        public virtual async Task<TAuthenticationResult> AuthenticateAsync(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            var user = await UserManager.FindByNameAsync(credentials.Username);

            if(user == null)
            {
                return DaAuthenticationResult<TKey>.Failed as TAuthenticationResult;
            }

            var validPassword = await UserManager.CheckPasswordAsync(user, credentials.Password);

            if(!validPassword)
            {
                return DaAuthenticationResult<TKey>.Failed as TAuthenticationResult;
            }

            if(user.IsDeleted)
            {
                return DaAuthenticationResult<TKey>.Deleted as TAuthenticationResult;
            }

            if(user.Status != DaAccountStatus.Active)
            {
                if (user.Status == DaAccountStatus.Inactive)
                {
                    return DaAuthenticationResult<TKey>.NotActive as TAuthenticationResult;
                }
                else if(user.Status == DaAccountStatus.Suspended)
                {
                    return DaAuthenticationResult<TKey>.Suspended as TAuthenticationResult;
                }
                else if(user.Status == DaAccountStatus.Closed)
                {
                    return DaAuthenticationResult<TKey>.Closed as TAuthenticationResult;
                }
            }

            var tenants = await TenantManager.FindByUserIdAsync(user.Id);
            List<TKey> tenantKeys = null;

            if(tenants != null && tenants.Count > 0)
            {
                if(tenants.Count == 1)
                {
                    if(tenants[0].Status != DaTenantStatus.Active)
                    {
                        return DaAuthenticationResult<TKey>.TenantNotActive as TAuthenticationResult;
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
                    foreach(var tenant in tenants)
                    {
                        if (tenant.Status == DaTenantStatus.Active)
                        {
                            tenantKeys.Add(tenant.Id);
                        }
                    }
                    
                    if(tenantKeys.Count <= 0)
                    {
                        return DaAuthenticationResult<TKey>.TenantNotActive as TAuthenticationResult;
                    }
                }
            }

            var result = await SignInManager.PasswordSignInAsync(credentials.Username, credentials.Password, credentials.RememberUser, lockoutOnFailure: false);

            if (result == SignInResult.Success)
            {
                string sessionId = null;
                string ipAddress = null;
                string deviceAgent = null;

                if (request != null)
                {
                    ipAddress = connection.RemoteIpAddress.ToString();
                    deviceAgent = request.Headers["User-Agent"].ToString();
                }

                if (session != null)
                {
                    sessionId = session.Id;
                }

                var userSession = new TUserSession()
                {
                    UserId = user.Id,
                    SessionKey = Guid.NewGuid().ToString(),
                    SystemSessionId = sessionId,
                    IpAddress = ipAddress,
                    DeviceAgent = deviceAgent,
                    Status = DaUserSessionStatus.New,
                    CreatedDateUtc = DateTime.UtcNow,
                    ExpiryDateUtc = DateTime.UtcNow.AddMinutes(expiryTimeInMinutes),
                    ExpiredDateUtc = null
                };

                await UserSessionManager.CreateAsync(userSession);
                session.SetString(USER_SESSION_KEY_SESSION_NAME, userSession.SessionKey);
            }

            if(result.Succeeded)
            {
                if(tenantKeys != null && tenantKeys.Count > 0)
                {
                    return DaAuthenticationResult<TKey>.SuccessWithTenants(tenantKeys) as TAuthenticationResult;                 
                }
            }

            return result as TAuthenticationResult;
        }

        public virtual async Task<TUserSession> GetAuthenticatedUserSessionAsync(ISession session)
        {
            var userSessionKey = session.GetString(USER_SESSION_KEY_SESSION_NAME);

            TUserSession userSession = default(TUserSession);

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                userSession = await UserSessionManager.FindBySessionKeyAsync(userSessionKey);
            }

            return userSession;
        }

        public TUserSession GetAuthenticatedUserSession(ISession session)
        {
            return DaAsyncHelper.RunSync(() => GetAuthenticatedUserSessionAsync(session));
        }

        public void SignOut(ISession session)
        {
            DaAsyncHelper.RunSync(() => SignOutAsync(session));
        }

        public virtual async Task SignOutAsync(ISession session)
        {
            var userSessionKey = session.GetString(USER_SESSION_KEY_SESSION_NAME);

            TUserSession userSession = default(TUserSession);

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                userSession = await UserSessionManager.FindBySessionKeyAsync(userSessionKey);
            }

            await SignInManager.SignOutAsync();

            if (userSession != null)
            {
                await UserSessionManager.UpdateStatusAsync(userSession.Id, DaUserSessionStatus.LoggedOff);
            }

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                session.Set(USER_SESSION_KEY_SESSION_NAME, null);
            }
        }
    }
}