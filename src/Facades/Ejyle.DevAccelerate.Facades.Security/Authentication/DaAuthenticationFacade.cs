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
using Ejyle.DevAccelerate.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Ejyle.DevAccelerate.Facades.Security.Authentication
{
    public class DaAuthenticationFacade : DaAuthenticationFacade<int, int?, DaUser, UserManager<DaUser>, SignInManager<DaUser>, DaTenant, DaTenantUser, DaTenantAttribute, DaTenantManager, DaUserSession, DaUserSessionManager>
    {
        public DaAuthenticationFacade(UserManager<DaUser> userManager, SignInManager<DaUser> signInManager, DaTenantManager tenantManager, DaUserSessionManager userSessionManager)
            : base(userManager, signInManager, tenantManager, userSessionManager)
        {
        }
    }

    public class DaAuthenticationFacade<TKey, TNullableKey, TUser, TUserManager, TSignInManager, TTenant, TTenantUser, TTenantAttribute, TTenantManager, TUserSession, TUserSessionManager>
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

        public SignInResult Authenticate(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            return DaAsyncHelper.RunSync<SignInResult>(() => AuthenticateAsync(request, session, connection, credentials, expiryTimeInMinutes));
        }

        public virtual async Task<SignInResult> AuthenticateAsync(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            var result = await SignInManager.PasswordSignInAsync(credentials.Username, credentials.Password, credentials.RememberUser, lockoutOnFailure: false);

            if (result == SignInResult.Success)
            {
                var user = await UserManager.FindByNameAsync(credentials.Username);

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

            return result;
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