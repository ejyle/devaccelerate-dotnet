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
using Ejyle.DevAccelerate.Workflow.SimpleWorkflow;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Workflow.Security.Authentication
{
    public class DaSignInWorkflowItem : DaSignInWorkflowItem<int, int?, DaUserManager, DaUser, DaUserLogin, DaUserRole, DaUserClaim, DaSignInManager, DaUserSession, DaUserSessionManager>
    { }

    public class DaSignInWorkflowItem<TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager> : DaSignInWorkflowItem<int, int?, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager>
        where TUserManager : DaUserManager<int, int?, TUser>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<int>
        where TUserRole : DaUserRole<int>
        where TUserClaim : DaUserClaim<int>
        where TUserSession : DaUserSession<int>, new()
        where TUserSessionManager : DaUserSessionManager<int, TUserSession>
        where TSignInManager : DaSignInManager<int, int?, TUserManager, TUser>, new()
    { }

    public class DaSignInWorkflowItem<TKey, TNullableKey, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager> : IDaSimpleWorkflowItemAction
        where TKey : IEquatable<TKey>
        where TUserManager : DaUserManager<TKey, TNullableKey, TUser>
        where TUser : DaUser<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<TKey>
        where TUserRole : DaUserRole<TKey>
        where TUserClaim : DaUserClaim<TKey>
        where TUserSession : DaUserSession<TKey>, new()
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
        where TSignInManager : DaSignInManager<TKey, TNullableKey, TUserManager, TUser>, new()
    {
        private IDaSimpleWorkflowItemSetting[] _settings;

        public void SetWorkflowItemSettings(IDaSimpleWorkflowItemSetting[] settings)
        {
            _settings = settings;
        }

        public async Task<DaSimpleWorkflowItemResult> ExecuteAsync(Dictionary<string, object> parameters)
        {
            var userManager = parameters["userManager"] as TUserManager;
            var signInManager = parameters["signInManager"] as TSignInManager;
            string userName = parameters["userName"] as string;
            string password = parameters["password"] as string;
            bool rememberMe = Convert.ToBoolean(parameters["rememberMe"]);
            var userSessionManager = parameters["userSessionManager"] as TUserSessionManager;
            var httpRequest = parameters["httpRequest"] as HttpRequest;
            var httpSession = parameters["httpSession"] as HttpSessionStateBase;

            var user = await userManager.FindByNameAsync(userName);
            var result = await signInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);

            if (result == SignInStatus.Success)
            {
                string sessionId = null;
                string ipAddress = null;
                string deviceAgent = null;
                int expiryTime = 30;

                if (httpRequest != null)
                {
                    ipAddress = httpRequest.UserHostAddress;
                    deviceAgent = httpRequest.UserAgent;
                }

                if (httpSession != null)
                {
                    sessionId = httpSession.SessionID;
                    expiryTime = httpSession.Timeout;
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

                await userSessionManager.CreateAsync(userSession);

                if (_settings != null)
                {
                    foreach (var setting in _settings)
                    {
                        if (setting.Name == "httpSessionName")
                        {
                            httpSession.Add(setting.Value, userSession.SessionKey);
                            break;
                        }
                    }
                }

                return new DaSimpleWorkflowItemResult((object)result);
            }

            List<string> errors = new List<string>();
            errors.Add(result.ToString());

            return new DaSimpleWorkflowItemResult(errors.ToArray());
        }
    }
}
