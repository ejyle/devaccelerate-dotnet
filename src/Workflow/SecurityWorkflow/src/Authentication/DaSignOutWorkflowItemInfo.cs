// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity;
using Ejyle.DevAccelerate.Identity.EF;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Ejyle.DevAccelerate.Identity.EF.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ejyle.DevAccelerate.Workflow.Security.Authentication
{
    public class DaSignOutWorkflowItemInfo
        : DaSignOutWorkflowItemInfo<DaUserManager, DaUser, DaUserLogin, DaUserRole, DaUserClaim, DaSignInManager, DaUserSession, DaUserSessionManager>
    {
        public DaSignOutWorkflowItemInfo(DaSignInManager signInManager, DaUserSessionManager userSessionManager, HttpRequestBase httpRequest, HttpSessionStateBase httpSession)
            : base(signInManager, userSessionManager, httpRequest, httpSession)
        {
        }
    }

    public class DaSignOutWorkflowItemInfo<TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager>
        : DaSignOutWorkflowItemInfo<int, int?, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager>
        where TUserManager : DaUserManager<int, int?, TUser>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>
        where TUserLogin : DaUserLogin<int>
        where TUserRole : DaUserRole<int>
        where TUserClaim : DaUserClaim<int>
        where TUserSession : DaUserSession<int>
        where TUserSessionManager : DaUserSessionManager<int, TUserSession>
        where TSignInManager : DaSignInManager<int, int?, TUserManager, TUser>
    {
        public DaSignOutWorkflowItemInfo(TSignInManager signInManager, TUserSessionManager userSessionManager, HttpRequestBase httpRequest, HttpSessionStateBase httpSession)
            : base(signInManager, userSessionManager, httpRequest, httpSession)
        {
        }
    }

    public class DaSignOutWorkflowItemInfo<TKey, TNullableKey, TUserManager, TUser, TUserLogin, TUserRole, TUserClaim, TSignInManager, TUserSession, TUserSessionManager>
        where TKey : IEquatable<TKey>
        where TUserManager : DaUserManager<TKey, TNullableKey, TUser>
        where TUser : DaUser<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>
        where TUserLogin : DaUserLogin<TKey>
        where TUserRole : DaUserRole<TKey>
        where TUserClaim : DaUserClaim<TKey>
        where TUserSession : DaUserSession<TKey>
        where TUserSessionManager : DaUserSessionManager<TKey, TUserSession>
        where TSignInManager : DaSignInManager<TKey, TNullableKey, TUserManager, TUser>
    {
        public DaSignOutWorkflowItemInfo(TSignInManager signInManager, TUserSessionManager userSessionManager, HttpRequestBase httpRequest, HttpSessionStateBase httpSession)
        {
            if (signInManager == null)
            {
                throw new ArgumentNullException(nameof(signInManager));
            }

            if (userSessionManager == null)
            {
                throw new ArgumentNullException(nameof(userSessionManager));
            }

            if (httpRequest == null)
            {
                throw new ArgumentNullException(nameof(httpRequest));
            }

            if (httpSession == null)
            {
                throw new ArgumentNullException(nameof(httpSession));
            }

            SignInManager = signInManager;
            UserSessionManager = userSessionManager;
            HttpRequest = httpRequest;
            HttpSession = httpSession;
        }

        public TSignInManager SignInManager
        {
            get;
            set;
        }

        public TUserSessionManager UserSessionManager
        {
            get;
            set;
        }

        public HttpSessionStateBase HttpSession
        {
            get;
            set;
        }

        public HttpRequestBase HttpRequest
        {
            get;
            set;
        }
    }
}
