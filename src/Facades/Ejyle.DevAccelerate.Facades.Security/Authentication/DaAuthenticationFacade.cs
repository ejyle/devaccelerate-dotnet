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
        where TAuthenticationResult : DaAuthenticationResult<TKey>, new()
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

        #region Obsolete Methods
        
        public DaAuthenticationResult<TKey> Authenticate(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            return DaAsyncHelper.RunSync<DaAuthenticationResult<TKey>>(() => AuthenticateAsync(request, session, connection, credentials, expiryTimeInMinutes));
        }

        public virtual async Task<DaAuthenticationResult<TKey>> AuthenticateAsync(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            var user = await UserManager.FindByNameAsync(credentials.Username);

            if (user == null)
            {
                return DaAuthenticationResult<TKey>.Failed;
            }

            var validPassword = await UserManager.CheckPasswordAsync(user, credentials.Password);

            if (!validPassword)
            {
                return DaAuthenticationResult<TKey>.Failed;
            }

            if (user.IsDeleted)
            {
                return DaAuthenticationResult<TKey>.Deleted;
            }

            if (user.Status != DaAccountStatus.Active)
            {
                if (user.Status == DaAccountStatus.Inactive)
                {
                    return DaAuthenticationResult<TKey>.NotActive;
                }
                else if (user.Status == DaAccountStatus.Suspended)
                {
                    return DaAuthenticationResult<TKey>.Suspended;
                }
                else if (user.Status == DaAccountStatus.Closed)
                {
                    return DaAuthenticationResult<TKey>.Closed;
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
                        return DaAuthenticationResult<TKey>.TenantNotActive;
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
                        return DaAuthenticationResult<TKey>.TenantNotActive;
                    }
                }
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

            if (tenantKeys != null && tenantKeys.Count > 0)
            {
                return DaAuthenticationResult<TKey>.SuccessWithTenants(tenantKeys);
            }
            else
            {
                return DaAuthenticationResult<TKey>.Success;
            }
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

        #endregion Obsolete Methods

        public DaAuthenticationResult<TKey> SignIn(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            return DaAsyncHelper.RunSync<DaAuthenticationResult<TKey>>(() => SignInAsync(request, session, connection, credentials, expiryTimeInMinutes));
        }


        public virtual async Task<DaAuthenticationResult<TKey>> SignInAsync(HttpRequest request, ISession session, ConnectionInfo connection, DaUserAccountCredentialsInfo credentials, int expiryTimeInMinutes = 30)
        {
            var validationResult = await ValidateUserCredentials(credentials);

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

            var userSession = new TUserSession()
            {
                UserId = validationResult.User.Id,
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

            var tenantKeys = validationResult.TenantKeys;

            if (tenantKeys != null && tenantKeys.Count > 0)
            {
                return DaAuthenticationResult<TKey>.SuccessWithTenants(tenantKeys);
            }
            else
            {
                return DaAuthenticationResult<TKey>.Success;
            }
        }

        public virtual async Task<TUserSession> GetSignedInUserSessionAsync(ISession session)
        {
            var userSessionKey = session.GetString(USER_SESSION_KEY_SESSION_NAME);

            TUserSession userSession = default(TUserSession);

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                userSession = await UserSessionManager.FindBySessionKeyAsync(userSessionKey);
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

        public DaAuthenticationResult<TKey> CreateUserSession(DaUserAccountCredentialsInfo credentials, string ipAddress, string deviceAgent, int? expiryTimeInMinutes = null)
        {
            return DaAsyncHelper.RunSync<DaAuthenticationResult<TKey>>(() => CreateUserSessionAsync(credentials, ipAddress, deviceAgent, expiryTimeInMinutes));
        }

        public virtual async Task<DaAuthenticationResult<TKey>> CreateUserSessionAsync(DaUserAccountCredentialsInfo credentials, string ipAddress, string deviceAgent, int? expiryTimeInMinutes = null)
        {
            if(expiryTimeInMinutes <= 0)
            {
                throw new InvalidOperationException("expiryTimeInMinutes must be greater than 0.");
            }

            var validationResult = await ValidateUserCredentials(credentials);

            if (!validationResult.Result.IsSuccess)
            {
                return validationResult.Result;
            }

            var userSession = new TUserSession()
            {
                UserId = validationResult.User.Id,
                SessionKey = Guid.NewGuid().ToString(),
                SystemSessionId = null,
                IpAddress = ipAddress,
                DeviceAgent = deviceAgent,
                Status = DaUserSessionStatus.New,
                CreatedDateUtc = DateTime.UtcNow,
                ExpiryDateUtc = null,
                ExpiredDateUtc = null
            };

            if(expiryTimeInMinutes != null)
            {
                userSession.ExpiryDateUtc = DateTime.UtcNow.AddMinutes((int)expiryTimeInMinutes);
            }

            await UserSessionManager.CreateAsync(userSession);

            var tenantKeys = validationResult.TenantKeys;

            if (tenantKeys != null && tenantKeys.Count > 0)
            {
                return DaAuthenticationResult<TKey>.SuccessWithTenants(tenantKeys);
            }
            else
            {
                return DaAuthenticationResult<TKey>.Success;
            }
        }

        private async Task<DaUserValidationResult> ValidateUserCredentials(DaUserAccountCredentialsInfo credentials)
        {
            var user = await UserManager.FindByNameAsync(credentials.Username);

            if (user == null)
            {
                return new DaUserValidationResult(DaAuthenticationResult<TKey>.Failed, null, null);
            }

            var validPassword = await UserManager.CheckPasswordAsync(user, credentials.Password);

            if (!validPassword)
            {
                return new DaUserValidationResult(DaAuthenticationResult<TKey>.Failed, null, null);
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

            return new DaUserValidationResult(DaAuthenticationResult<TKey>.Success, user, tenantKeys);
        }

        private class DaUserValidationResult
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