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
    public class DaSignInWorkflowItem : DaSignInWorkflowItem<int, int?, DaSignInWorkflowItemInfo, DaUserManager, DaUser, DaUserLogin, DaUserRole, DaUserClaim, DaSignInManager, DaUserSession, DaUserSessionManager>
    { }

    public class DaSignInWorkflowItem<TSignInWorkflowItemInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager> : DaSignInWorkflowItem<int, int?, TSignInWorkflowItemInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager>
        where TSignInWorkflowItemInfo : DaSignInWorkflowItemInfo<TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager>
        where TUserManager : DaUserManager<int, int?, TUser>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<int>
        where TUserRole : DaUserRole<int>
        where TUserClaim : DaUserClaim<int>
        where TUserSession : DaUserSession<int>, new()
        where TUserSessionManager : DaUserSessionManager<int, TUserSession>
        where TSignInManager : DaSignInManager<int, int?, TUserManager, TUser>, new()
    { }

    public class DaSignInWorkflowItem<TKey, TNullableKey, TSignInWorkflowItemInfo, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager> : IDaSimpleWorkflowItemAction
        where TKey : IEquatable<TKey>
        where TUserManager : DaUserManager<TKey, TNullableKey, TUser>
        where TSignInWorkflowItemInfo : DaSignInWorkflowItemInfo<TKey, TNullableKey, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager>
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
            var signInInfo = parameters["signInInfo"] as TSignInWorkflowItemInfo;
            
            var user = await signInInfo.SignInManager.UserManager.FindByNameAsync(signInInfo.UserName);
            var result = await signInInfo.SignInManager.PasswordSignInAsync(signInInfo.UserName, signInInfo.Password, signInInfo.RememberMe, shouldLockout: false);

            if (result == SignInStatus.Success)
            {
                string sessionId = null;
                string ipAddress = null;
                string deviceAgent = null;
                int expiryTime = 30;

                if (signInInfo.HttpRequest != null)
                {
                    ipAddress = signInInfo.HttpRequest.UserHostAddress;
                    deviceAgent = signInInfo.HttpRequest.UserAgent;
                }

                if (signInInfo.HttpSession != null)
                {
                    sessionId = signInInfo.HttpSession.SessionID;
                    expiryTime = signInInfo.HttpSession.Timeout;
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

                await signInInfo.UserSessionManager.CreateAsync(userSession);

                if (_settings != null)
                {
                    foreach (var setting in _settings)
                    {
                        if (setting.Name == "httpSessionName")
                        {
                            signInInfo.HttpSession.Add(setting.Value, userSession.SessionKey);
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
