// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.Exceptions;
using Ejyle.DevAccelerate.Core.Logging;

namespace Ejyle.DevAccelerate.Core.EF
{
    /// <summary>
    /// Represents the common functionality for entity repositories that use Entity Framework for data access.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDbContext">The <see cref="DbContext"/> type.</typeparam>
    public abstract class DaEntityRepositoryBase<TKey, TEntity, TDbContext> : IDaEntityRepository<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : IDaEntity<TKey>
        where TDbContext : DbContext
    {
        private bool _isDisposed = false;
        private TDbContext _dbContext;
        private bool _applyDispose = true;

        /// <summary>
        /// Creates an instance of the <see cref="DaEntityRepositoryBase{TKey, TEntity, TDbContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The DbContext instance to be used by the repository.</param>
        public DaEntityRepositoryBase(TDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }

            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaEntityRepositoryBase{TKey, TEntity, TDbContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The DbContext instance to be used by the repository.</param>
        /// <param name="applyDispose">Determines if the DbContext is to be disposed as well when the entity repository is disposed.</param>
        public DaEntityRepositoryBase(TDbContext dbContext, bool applyDispose)
        {
            if(dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }

            _dbContext = dbContext;
            _applyDispose = applyDispose;
        }

        /// <summary>
        /// Gets the DbContext of the repository.
        /// </summary>
        protected TDbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        /// <summary>Saves the current changes.</summary>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        protected Task SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        protected void Log(string message)
        {
            var logManager = DaLogManagerFactory.CreateLogManager();

            if (logManager != null)
            {
                var msg = new DaLogMessage()
                {
                    Text = message,
                    Priority = 1,
                    Date = DateTime.UtcNow,
                };

                logManager.Write(msg);
            }
        }

        /// <summary>
        /// Logs a message with a given category.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="category">The category with which the log message is to be associated with.</param>
        protected void Log(string message, string category)
        {
            var logManager = DaLogManagerFactory.CreateLogManager();

            if (logManager != null)
            {
                var msg = new DaLogMessage()
                {
                    Text = message,
                    Priority = 1,
                    Date = DateTime.UtcNow,
                };

                msg.Categories.Add(category);

                logManager.Write(msg);
            }
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        protected void Log(IDaLogMessage message)
        {
            var logManager = DaLogManagerFactory.CreateLogManager();

            if (logManager != null)
            {
                logManager.Write(message);
            }
        }

        /// <summary>
        /// Handles an exception.
        /// </summary>
        /// <param name="ex">The exception to handle.</param>
        protected void HandleException(Exception ex)
        {
            var exceptionManager = DaExceptionManagerFactory.CreateExceptionManager();

            if (exceptionManager != null)
            {
                exceptionManager.HandleExpcetion(ex);
            }
        }

        /// <summary>
        /// Handles an exception.
        /// </summary>
        /// <param name="ex">The exception to handle.</param>
        /// <param name="exceptionPolicy">The exception policy to use for handling the exception.</param>
        protected void HandleException(Exception ex, string exceptionPolicy)
        {
            var exceptionManager = DaExceptionManagerFactory.CreateExceptionManager();

            if (exceptionManager != null)
            {
                exceptionManager.HandleExpcetion(ex, exceptionPolicy);
            }
        }

        /// <summary>
        /// Releases the resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_applyDispose)
            {
                if (!_isDisposed)
                {
                    if (disposing)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }

                    _isDisposed = true;
                }
            }
        }

        /// <summary>
        /// Triggers the <see cref="Dispose(bool)"/> method.
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
        /// <param name="arg">The argument</param>
        /// <param name="parameterName">The name of the parameter</param>
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
        /// <param name="arg">The argument</param>
        /// <param name="parameterName">The name of the parameter</param>
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
        /// <param name="arg">The argument</param>
        /// <param name="parameterName">The name of the parameter</param>
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
        /// <param name="arg">The argument</param>
        /// <param name="parameterName">The name of the parameter</param>
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
