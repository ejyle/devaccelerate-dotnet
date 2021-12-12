// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the base class for entity managers with common properties and methods.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class DaEntityManagerBase<TKey, TEntity> : IDaEntityManager<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : IDaEntity<TKey>
    {
        private bool _isDisposed = false;

        /// <summary>
        /// Creates an instance of the <see cref="IDaEntityRepository{TKey, TEntity}"/> class.
        /// </summary>
        /// <param name="repository">The repository to be used by the entity manager.</param>
        public DaEntityManagerBase(IDaEntityRepository<TKey, TEntity> repository)
        {
            Repository = repository ?? throw new ArgumentNullException("repository");
        }

        /// <summary>
        /// Gets an instance of the <see cref="IDaEntityRepository{TKey, TEntity}"/> type used by the entity manager.
        /// </summary>
        private IDaEntityRepository<TKey, TEntity> Repository;

        /// <summary>
        /// Gets the repository be a given generic repository type.
        /// </summary>
        /// <typeparam name="TEntityRepository">The type of the repository.</typeparam>
        /// <returns>Returns an instance of the <see cref="IDaEntityRepository{TKey, TEntity}"/> type.</returns>
        protected TEntityRepository GetRepository<TEntityRepository>()
            where TEntityRepository : IDaEntityRepository<TKey, TEntity>
        {
            if(Repository == null)
            {
                return default(TEntityRepository);
            }

            return (TEntityRepository)Repository;
        }

        /// <summary>
        /// Disposes the resources of the entity manager. Do not call this method explicitly.
        /// </summary>
        /// <param name="disposing">Determines if the resources are being disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                   if(Repository != null)
                    {
                        Repository.Dispose();
                        Repository = null;
                    }
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Disposes the resources of the entity manager.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Throws <see cref="ObjectDisposedException"/> exception if the <see cref="Dispose()"/> method has already been called. 
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given argument is null.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        protected void ThrowIfArgumentIsNull(TEntity arg, string parameterName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given argument is null.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        protected void ThrowIfArgumentIsNull(List<TEntity> arg, string parameterName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given argument is null.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        protected void ThrowIfArgumentIsNull<TEntityArg>(TEntityArg arg, string parameterName)
            where TEntityArg : IDaEntity<TKey>
        {
            if (arg == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given argument is null.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        protected void ThrowIfArgumentIsNull<TEntityArg>(List<TEntityArg> arg, string parameterName)
            where TEntityArg : IDaEntity<TKey>
        {
            if (arg == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given string argument is null.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        protected void ThrowIfArgumentIsNull(string arg, string parameterName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given string argument is null or empty.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        protected void ThrowIfArgumentIsNullOrEmpty(string arg, string parameterName)
        {
            if (string.IsNullOrEmpty(arg))
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}