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
    public class DaSignOutWorkflowItem : DaSignOutWorkflowItem<int, int?, DaUserManager, DaUser, DaUserLogin, DaUserRole, DaUserClaim, DaSignInManager, DaUserSession, DaUserSessionManager>
    { }

    public class DaSignOutWorkflowItem<TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager> : DaSignOutWorkflowItem<int, int?, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager>
        where TUserManager : DaUserManager<int, int?, TUser>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<int>
        where TUserRole : DaUserRole<int>
        where TUserClaim : DaUserClaim<int>
        where TUserSession : DaUserSession<int>, new()
        where TSignInManager : DaSignInManager<int, int?, TUserManager, TUser>, new()
        where TUserSessionManager : DaUserSessionManager<int, TUserSession>
    { }

    public class DaSignOutWorkflowItem<TKey, TNullableKey, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager> : IDaSimpleWorkflowItemAction
        where TKey : IEquatable<TKey>
        where TUserManager : DaUserManager<TKey, TNullableKey, TUser>
        where TUser : DaUser<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>, new()
        where TUserLogin : DaUserLogin<TKey>
        where TUserRole : DaUserRole<TKey>
        where TUserClaim : DaUserClaim<TKey>
        where TUserSession : DaUserSession<TKey>, new()
        where TSignInManager : DaSignInManager<TKey, TNullableKey, TUserManager, TUser>, new()
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
    {
        private IDaSimpleWorkflowItemSetting[] _settings;

        public void SetWorkflowItemSettings(IDaSimpleWorkflowItemSetting[] settings)
        {
            _settings = settings;
        }

        public async Task<DaSimpleWorkflowItemResult> ExecuteAsync(Dictionary<string, object> parameters)
        {
            var signInManager = parameters["signInManager"] as TSignInManager;
            var userSessionManager = parameters["userSessionManager"] as TUserSessionManager;
            var httpSession = parameters["httpSession"] as HttpSessionStateBase;

            TUserSession userSession = default(TUserSession);
            string userSessionKey = null;
            string sessionName = null;

            if (_settings != null)
            {
                foreach (var setting in _settings)
                {
                    if (setting.Name == "httpSessionName")
                    {
                        sessionName = setting.Value;
                        userSessionKey = httpSession[sessionName] as string;
                        userSession = default(TUserSession);

                        if (!string.IsNullOrEmpty(userSessionKey))
                        {
                            userSession = await userSessionManager.FindBySessionKeyAsync(userSessionKey);
                        }

                        break;
                    }
                }
            }

            signInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            if (userSession != null)
            {
                await userSessionManager.UpdateStatusAsync(userSession.Id, DaUserSessionStatus.LoggedOff);
            }

            if (!string.IsNullOrEmpty(userSessionKey))
            {
                httpSession[sessionName] = null;
            }

            return new DaSimpleWorkflowItemResult((object)userSessionKey);
        }
    }
}
