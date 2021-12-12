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
    /// <summary>
    /// Provides an interface for storing and retrieving user agreements in the repository.
    /// </summary>
    /// <typeparam name="TKey">The type of an entity key.</typeparam>
    /// <typeparam name="TNullableKey">The type of a nullable key.</typeparam>
    /// <typeparam name="TUserAgreement">The type of <see cref="IDaUserAgreement{TKey, TNullableKey}"/>.</typeparam>
    /// <typeparam name="TUserAgreementVersion">The type of <see cref="IDaUserAgreementVersion{TKey}"/>.</typeparam>
    public interface IDaUserAgreementRepository<TKey, TNullableKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction> : IDaEntityRepository<TKey, TUserAgreement>
        where TKey : IEquatable<TKey>
        where TUserAgreement : IDaUserAgreement<TKey, TNullableKey>
        where TUserAgreementVersion : IDaUserAgreementVersion<TKey>
        where TUserAgreementVersionAction : IDaUserAgreementVersionAction<TKey>
    {
        /// <summary>
        /// Asynchronously creates a user agreement in the given repository.
        /// </summary>
        /// <param name="userAgreement">The agreement to create.</param>
        /// <returns>The Task that represents the asynchronous operation.</returns>
        Task CreateAsync(TUserAgreement userAgreement);

        /// <summary>
        /// Asynchronously creates a user agreement version in the given repository.
        /// </summary>
        /// <param name="userAgreementVersionUser">The user agreement version to create.</param>
        /// <returns>The Task that represents the asynchronous operation.</returns>
        Task CreateAsync(TUserAgreementVersionAction userAgreementVersionUser);

        /// <summary>
        /// Asynchronously updates a user agreement in the given repository.
        /// </summary>
        /// <param name="userAgreement">The agreement to update.</param>
        /// <returns>The Task that represents the asynchronous operation.</returns>
        Task UpdateAsync(TUserAgreement userAgreement);

        /// <summary>
        /// Asynchronously finds and returns a user agreement by its ID.
        /// </summary>
        /// <param name="userAgreementId">The ID of the user agreement.</param>
        /// <returns>The Task that represents the asynchronous operation containing the user agreement.</returns>
        Task<TUserAgreement> FindByIdAsync(TKey userAgreementId);

        /// <summary>
        /// Asynchronously finds and returns a user agreement by its key.
        /// </summary>
        /// <param name="key">The key of the user agreement.</param>
        /// <returns>The Task that represents the asynchronous operation containing the user agreement.</returns>
        Task<TUserAgreement> FindByKeyAsync(string key);

        /// <summary>
        /// Asynchronously finds a user agreement by its associated user agreement version ID.
        /// </summary>
        /// <param name="userAgreementVersionId">The ID of the user agreement version.</param>
        /// <returns>Returns an instance of the TUserAgreement type.</returns>
        Task<TUserAgreement> FindByVersionIdAsync(TKey userAgreementVersionId);

        /// <summary>
        /// Asyncrhonously finds and returns user agreement versions with a given key.
        /// </summary>
        /// <param name="key">The key of the user agreement.</param>
        /// <returns></returns>
        Task<TUserAgreementVersion> FindCurrentUserAgreementVersionAsync(string key);
    }
}
