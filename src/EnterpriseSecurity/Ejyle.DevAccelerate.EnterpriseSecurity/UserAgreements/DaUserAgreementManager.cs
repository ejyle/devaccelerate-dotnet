// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.EnterpriseSecurity.UserAgreements
{
    public class DaUserAgreementManager<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction> : DaEntityManagerBase<TKey, TUserAgreement>
        where TKey : IEquatable<TKey>
        where TUserAgreement : IDaUserAgreement<TKey>
        where TUserAgreementVersion : IDaUserAgreementVersion<TKey>
        where TUserAgreementVersionAction : IDaUserAgreementVersionAction<TKey>
    {
        public DaUserAgreementManager(IDaUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction> repository)
            : base(repository)
        { }

        private IDaUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction> GetRepository()
        {
            return GetRepository<IDaUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>>();
        }

        public Task CreateAsync(TUserAgreement userAgreement)
        {
            return GetRepository().CreateAsync(userAgreement);
        }

        public Task CreateAsync(TUserAgreementVersionAction userAgreementVersionUser)
        {
            return GetRepository().CreateAsync(userAgreementVersionUser);
        }

        public Task<TUserAgreement> FindByIdAsync(TKey userAgreementId)
        {
            return GetRepository().FindByIdAsync(userAgreementId);
        }

        public Task<TUserAgreement> FindByKeyAsync(string key)
        {
            return GetRepository().FindByKeyAsync(key);
        }

        public Task UpdateAsync(TUserAgreement userAgreement)
        {
            return GetRepository().UpdateAsync(userAgreement);
        }

        public Task<TUserAgreement> FindByVersionIdAsync(TKey userAgreementVersionId)
        {
            return GetRepository().FindByVersionIdAsync(userAgreementVersionId);
        }

        public Task<TUserAgreementVersion> FindCurrentUserAgreementVersionAsync(string key)
        {
            return GetRepository().FindCurrentUserAgreementVersionAsync(key);
        }
    }
}
