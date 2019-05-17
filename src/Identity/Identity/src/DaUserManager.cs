// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ejyle.DevAccelerate.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Identity.Configuration;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents the core functionality for creating and managing user accounts.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    public class DaUserManager<TUser>
        : DaUserManager<int, int?, TUser>
        where TUser : class, IDaUser<int, int?>, Microsoft.AspNet.Identity.IUser<int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public DaUserManager(IDaUserRepository<int, int?, TUser> repository)
            : base(repository)
        {
        }
    }

    /// <summary>
    /// Represents the core functionality for creating and managing user accounts.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TNullableKey"></typeparam>
    /// <typeparam name="TUser"></typeparam>
    public class DaUserManager<TKey, TNullableKey, TUser>
        : Microsoft.AspNet.Identity.UserManager<TUser, TKey>, IDaEntityManager<TKey, TUser>
        where TKey : IEquatable<TKey>
        where TUser : class, IDaUser<TKey, TNullableKey>, Microsoft.AspNet.Identity.IUser<TKey>
    {
        public const string GLOBAL_SUPER_ADMIN_USER = "GlobalSuperAdmin";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public DaUserManager(IDaUserRepository<TKey, TNullableKey, TUser> repository)
            : base((IUserStore<TUser, TKey>)repository)
        {
            var configSection = DaIdentityConfigurationManager.GetConfiguration();

            if (configSection != null)
            {
                var userNamePolicy = configSection.UserNamePolicy;

                if (userNamePolicy != null)
                {
                    UserValidator = new UserValidator<TUser, TKey>(this)
                    {
                        AllowOnlyAlphanumericUserNames = userNamePolicy.AllowOnlyAlphanumericUserNames,
                        RequireUniqueEmail = userNamePolicy.RequireUniqueEmail
                    };
                }

                var passwordPolicy = configSection.PasswordPolicy;

                if (passwordPolicy != null)
                {
                    PasswordValidator = new PasswordValidator
                    {
                        RequiredLength = passwordPolicy.MinRequiredLength,
                        RequireNonLetterOrDigit = passwordPolicy.RequireSpecialCharacters,
                        RequireDigit = passwordPolicy.RequireDigits,
                        RequireLowercase = passwordPolicy.RequireLowerCase,
                        RequireUppercase = passwordPolicy.RequireUpperCase,
                    };
                }

                var userLockoutPolicy = configSection.UserLockoutPolicy;

                if (userLockoutPolicy != null)
                {
                    UserLockoutEnabledByDefault = userLockoutPolicy.UserLockoutEnabledByDefault;
                    DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(userLockoutPolicy.DefaultLockoutTimeSpan);
                    MaxFailedAccessAttemptsBeforeLockout = userLockoutPolicy.MaxFailedAccessAttemptsBeforeLockout;
                }
            }

            RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<TUser, TKey>
            {
                MessageFormat = "Your security code is {0}"
            });

            RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<TUser, TKey>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            EmailService = new DaEmailService();
            SmsService = new DaSmsService();
        }

        private IDaUserRepository<TKey, TNullableKey, TUser> Repository
        {
            get
            {
                return Store as IDaUserRepository<TKey, TNullableKey, TUser>;
            }
        }

        public override async Task<IdentityResult> ChangePasswordAsync(TKey userId, string currentPassword, string newPassword)
        {
            var user = await base.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("Cannot change password because user is not found.");
            }

            var hashedPassword = base.PasswordHasher.HashPassword(newPassword);

            var isDuplicatePassword = await Repository.IsPasswordInHistoryAsync(user.Id, hashedPassword);

            if(isDuplicatePassword)
            {
                throw new InvalidOperationException("Duplicate password.");
            }

            var result = await base.ChangePasswordAsync(user.Id, currentPassword, newPassword);

            if (result.Succeeded)
            {
                await Repository.RecordPasswordHistoryAsync(user.Id, hashedPassword);

                if (user.RequireChangePassword)
                {
                    user.RequireChangePassword = false;
                    await base.UpdateAsync(user);
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual IdentityResult Create(TUser user)
        {
            return DaAsyncHelper.RunSync<IdentityResult>(() => base.CreateAsync(user));
        }

        public virtual IdentityResult Create(TUser user, string password)
        {
            return DaAsyncHelper.RunSync<IdentityResult>(() => base.CreateAsync(user, password));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual IdentityResult Update(TUser user)
        {
            return DaAsyncHelper.RunSync<IdentityResult>(() => base.UpdateAsync(user));
        }
    }
}
