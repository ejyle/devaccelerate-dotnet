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
    public class DaAuthenticationFacade : DaAuthenticationFacade<string, DaUser, UserManager<DaUser>, SignInManager<DaUser>, DaTenant, DaTenantUser, DaTenantAttribute, DaTenantManager, DaUserSession, DaUserSessionManager, DaAuthenticationResult>
    {
        public DaAuthenticationFacade(UserManager<DaUser> userManager, SignInManager<DaUser> signInManager, DaTenantManager tenantManager, DaUserSessionManager userSessionManager)
            : base(userManager, signInManager, tenantManager, userSessionManager)
        {
        }
    }

    public class DaAuthenticationFacade<TKey, TUser, TUserManager, TSignInManager, TTenant, TTenantUser, TTenantAttribute, TTenantManager, TUserSession, TUserSessionManager, TAuthenticationResult>
        : DaAuthenticationFacadeBase<TKey, TUser, TUserManager, TSignInManager, TTenant, TTenantUser, TTenantAttribute, TTenantManager, TUserSession, TUserSessionManager, TAuthenticationResult>
        where TKey : IEquatable<TKey>
        where TUser : DaUser<TKey>
        where TUserManager : UserManager<TUser>
        where TSignInManager : SignInManager<TUser>
        where TTenantManager : DaTenantManager<TKey, TTenant>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute>, new()
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TTenant>, new()
        where TUserSession : DaUserSession<TKey>, new()
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
        where TAuthenticationResult : DaAuthenticationResult<TKey>, new()
    {
        private const string USER_SESSION_KEY_SESSION_NAME = "DaAuthenticationFacade_SessionKey";

        public DaAuthenticationFacade(UserManager<TUser> userManager, SignInManager<TUser> signInManager, TTenantManager tenantManager, TUserSessionManager userSessionManager)
            : base(userManager, signInManager, tenantManager, userSessionManager)
        { }

        public DaAuthenticationResult<TKey> SignIn(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            return DaAsyncHelper.RunSync<DaAuthenticationResult<TKey>>(() => SignInAsync(request, session, connection, credentials, expiryTimeInMinutes));
        }


        public virtual async Task<DaAuthenticationResult<TKey>> SignInAsync(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            var validationResult = await ValidateUserCredentialsAsync(credentials.Username, credentials.Password, true);

            if(!validationResult.Result.IsSuccess)
            {
                return validationResult.Result;
            }

            var result = await SignInManager.PasswordSignInAsync(credentials.Username, credentials.Password, credentials.RememberUser, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    return DaAuthenticationResult<TKey>.LockedOut;
                }
                else if (result.IsNotAllowed)
                {
                    return DaAuthenticationResult<TKey>.NotAllowed;
                }
                else if (result.RequiresTwoFactor)
                {
                    return DaAuthenticationResult<TKey>.TwoFactorRequired;
                }
                else
                {
                    return DaAuthenticationResult<TKey>.Failed;
                }
            }

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

            var userSession = await CreateUserSessionAsync(validationResult.User.Id, sessionId, ipAddress, deviceAgent, expiryTimeInMinutes); ;
            session.SetString(USER_SESSION_KEY_SESSION_NAME, userSession.AccessToken);

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

        public virtual async Task<TUserSession> GetSignedInUserSessionAsync(ISession session)
        {
            var userSessionKey = session.GetString(USER_SESSION_KEY_SESSION_NAME);

            TUserSession userSession = default(TUserSession);

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                userSession = await UserSessionManager.FindByAccessTokenAsync(userSessionKey);
            }

            return userSession;
        }

        public TUserSession GetSignedInUserSession(ISession session)
        {
            return DaAsyncHelper.RunSync(() => GetSignedInUserSessionAsync(session));
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
                userSession = await UserSessionManager.FindByAccessTokenAsync(userSessionKey);
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