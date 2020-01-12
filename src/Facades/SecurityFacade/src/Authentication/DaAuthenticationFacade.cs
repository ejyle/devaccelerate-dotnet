// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ejyle.DevAccelerate.EnterpriseSecurity.Tenants;
using Ejyle.DevAccelerate.EnterpriseSecurity.EF.Tenants;
using Ejyle.DevAccelerate.Identity;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.Identity.EF.UserSessions;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Microsoft.Owin;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Facades.Security.Authentication
{
    public class DaAuthenticationFacade : DaAuthenticationFacade<int, int?, DaUserManager, DaUser, DaUserLogin, DaUserRole, DaUserClaim, DaTenantManager, DaTenant, DaTenantUser, DaTenantAttribute, DaSignInManager, DaUserSession, DaUserSessionManager>
    {
        public DaAuthenticationFacade(IOwinContext owinContext)
            : base(owinContext.Get<DaUserManager>(),
                  new DaTenantManager(new DaTenantRepository(owinContext.Get<DaIdentityDbContext>())),
                  owinContext.Get<DaSignInManager>(),
                  new DaUserSessionManager(new DaUserSessionRepository(owinContext.Get<DaIdentityDbContext>())))
        { }

        public DaAuthenticationFacade(DaUserManager userManager, DaTenantManager tenantManager, DaSignInManager signInManager, DaUserSessionManager userSessionManager)
            : base(userManager, tenantManager, signInManager, userSessionManager)
        {
        }
    }

    public class DaAuthenticationFacade<TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TTenantManager, TTenant, TTenantUser, TTenantAttribute, TSignInManager, TUserSession, TUserSessionManager> : DaAuthenticationFacade<int, int?, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TTenantManager, TTenant, TTenantUser, TTenantAttribute, TSignInManager, TUserSession, TUserSessionManager>
        where TUserManager : DaUserManager<int, int?, TUser>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<int>
        where TUserRole : DaUserRole<int>
        where TUserClaim : DaUserClaim<int>
        where TTenantManager : DaTenantManager<int, int?, TTenant>
        where TTenant : DaTenant<int, int?, TTenantUser, TTenantAttribute>, new()
        where TTenantAttribute : DaTenantAttribute<int, int?, TTenant>
        where TTenantUser : DaTenantUser<int, int?, TTenant>, new()
        where TUserSession : DaUserSession<int>, new()
        where TSignInManager : DaSignInManager<int, int?, TUserManager, TUser>, new()
        where TUserSessionManager : DaUserSessionManager<int, TUserSession>
    {
        public DaAuthenticationFacade(TUserManager userManager, TTenantManager tenantManager, TSignInManager signInManager, TUserSessionManager userSessionManager)
            : base(userManager, tenantManager, signInManager, userSessionManager)
        {
        }
    }

    public class DaAuthenticationFacade<TKey, TNullableKey, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TTenantManager, TTenant, TTenantUser, TTenantAttribute, TSignInManager, TUserSession, TUserSessionManager>
        where TKey : IEquatable<TKey>
        where TUserManager : DaUserManager<TKey, TNullableKey, TUser>
        where TUser : DaUser<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<TKey>
        where TUserRole : DaUserRole<TKey>
        where TUserClaim : DaUserClaim<TKey>
        where TTenantManager : DaTenantManager<TKey, TNullableKey, TTenant>
        where TTenant : DaTenant<TKey, TNullableKey, TTenantUser, TTenantAttribute>, new()
        where TTenantAttribute : DaTenantAttribute<TKey, TNullableKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TNullableKey, TTenant>, new()
        where TUserSession : DaUserSession<TKey>, new()
        where TSignInManager : DaSignInManager<TKey, TNullableKey, TUserManager, TUser>, new()
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
    {
        private const string USER_SESSION_KEY_SESSION_NAME = "DaAuthenticationFacade_SessionKey";

        public DaAuthenticationFacade(TUserManager userManager, TTenantManager tenantManager, TSignInManager signInManager, TUserSessionManager userSessionManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            TenantManager = tenantManager ?? throw new ArgumentNullException(nameof(tenantManager));
            SignInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            UserSessionManager = userSessionManager ?? throw new ArgumentNullException(nameof(userSessionManager));
        }

        public TUserManager UserManager
        {
            get;
            private set;
        }

        public TTenantManager TenantManager
        {
            get;
            private set;
        }

        public TSignInManager SignInManager
        {
            get;
            private set;
        }

        public TUserSessionManager UserSessionManager
        {
            get;
            private set;
        }

        public SignInStatus Authenticate(HttpRequestBase request, HttpSessionStateBase session, DaUserAccountCredentialsInfo credentials)
        {
            return DaAsyncHelper.RunSync<SignInStatus>(() => AuthenticateAsync(request, session, credentials));
        }

        public virtual async Task<SignInStatus> AuthenticateAsync(HttpRequestBase request, HttpSessionStateBase session, DaUserAccountCredentialsInfo credentials)
        {
            var result = await SignInManager.PasswordSignInAsync(credentials.Username, credentials.Password, credentials.RememberUser, shouldLockout: false);

            if (result == SignInStatus.Success)
            {
                var user = await UserManager.FindByNameAsync(credentials.Username);

                string sessionId = null;
                string ipAddress = null;
                string deviceAgent = null;
                int expiryTime = 30;

                if (request != null)
                {
                    ipAddress = request.UserHostAddress;
                    deviceAgent = request.UserAgent;
                }

                if (session != null)
                {
                    sessionId = session.SessionID;
                    expiryTime = session.Timeout;
                }

                var userSession = new TUserSession()
                {
                    UserId = user.Id,
                    SessionKey = Guid.NewGuid().ToString(),
                    SystemSessionId = sessionId,
                    IpAddress = ipAddress,
                    DeviceAgent = deviceAgent,
                    CreatedDateUtc = DateTime.UtcNow,
                    ExpiryDateUtc = DateTime.UtcNow.AddMinutes(expiryTime),
                    ExpiredDateUtc = null
                };

                await UserSessionManager.CreateAsync(userSession);
                session.Add(USER_SESSION_KEY_SESSION_NAME, userSession.SessionKey);
            }

            return result;
        }

        public virtual async Task<TUserSession> GetAuthenticatedUserSessionAsync(HttpSessionStateBase session)
        {
            var userSessionKey = session[USER_SESSION_KEY_SESSION_NAME] as string;

            TUserSession userSession = default(TUserSession);

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                userSession = await UserSessionManager.FindBySessionKeyAsync(userSessionKey);
            }

            return userSession;
        }

        public TUserSession GetAuthenticatedUserSession(HttpSessionStateBase session)
        {
            return DaAsyncHelper.RunSync(() => GetAuthenticatedUserSessionAsync(session));
        }

        public void SignOut(HttpSessionStateBase session)
        {
            DaAsyncHelper.RunSync(() => SignOutAsync(session));
        }

        public virtual async Task SignOutAsync(HttpSessionStateBase session)
        {
            var userSessionKey = session[USER_SESSION_KEY_SESSION_NAME] as string;

            TUserSession userSession = default(TUserSession);

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                userSession = await UserSessionManager.FindBySessionKeyAsync(userSessionKey);
            }

            SignInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            if (userSession != null)
            {
                await UserSessionManager.UpdateStatusAsync(userSession.Id, DaUserSessionStatus.LoggedOff);
            }

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                session[USER_SESSION_KEY_SESSION_NAME] = null;
            }
        }
    }
}