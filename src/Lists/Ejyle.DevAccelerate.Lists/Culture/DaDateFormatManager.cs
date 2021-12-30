// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists.Culture
{
    public class DaDateFormatManager<TKey, TDateFormat>
        : DaEntityManagerBase<TKey, TDateFormat>
        where TKey : IEquatable<TKey>
        where TDateFormat : IDaDateFormat<TKey>
    {
        public DaDateFormatManager(IDaDateFormatRepository<TKey, TDateFormat> repository)
            : base(repository)
        { }

        protected virtual IDaDateFormatRepository<TKey, TDateFormat> Repository
        {
            get
            {
                return GetRepository<IDaDateFormatRepository<TKey, TDateFormat>>();
            }
        }

        public void Create(TDateFormat dateFormat)
        {
            DaAsyncHelper.RunSync(() => CreateAsync(dateFormat));
        }

        public Task CreateAsync(TDateFormat dateFormat)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(dateFormat, nameof(dateFormat));

            return Repository.CreateAsync(dateFormat);
        }

        public void Update(TDateFormat dateFormat)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(dateFormat, nameof(dateFormat));

            DaAsyncHelper.RunSync(() => UpdateAsync(dateFormat));
        }

        public Task UpdateAsync(TDateFormat dateFormat)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(dateFormat, nameof(dateFormat));

            return Repository.UpdateAsync(dateFormat);
        }

        public void Delete(TDateFormat dateFormat)
        {
            DaAsyncHelper.RunSync(() => DeleteAsync(dateFormat));
        }

        public Task DeleteAsync(TDateFormat dateFormat)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(dateFormat, nameof(dateFormat));

            return Repository.DeleteAsync(dateFormat);
        }

        public TDateFormat Find()
        {
            return DaAsyncHelper.RunSync<TDateFormat>(() => FindAsync());
        }

        public Task<TDateFormat> FindAsync()
        {
            ThrowIfDisposed();
            return Repository.FindFirstAsync();
        }

        public List<TDateFormat> FindAll()
        {
            return DaAsyncHelper.RunSync<List<TDateFormat>>(() => FindAllAsync());
        }

        public Task<List<TDateFormat>> FindAllAsync()
        {
            ThrowIfDisposed();
            return Repository.FindAllAsync();
        }

        public TDateFormat FindById(TKey id)
        {
            return DaAsyncHelper.RunSync<TDateFormat>(() => FindByIdAsync(id));
        }

        public Task<TDateFormat> FindByIdAsync(TKey id)
        {
            ThrowIfDisposed();
            return Repository.FindByIdAsync(id);
        }

        public TDateFormat FindByDateFormatExpression(string expr)
        {
            return DaAsyncHelper.RunSync<TDateFormat>(() => FindByDateFormatExpressionAsync(expr));
        }

        public Task<TDateFormat> FindByDateFormatExpressionAsync(string expr)
        {
            ThrowIfDisposed();
            ThrowIfArgumentIsNull(expr, nameof(expr));

            return Repository.FindByDateFormatExpressionAsync(expr);
        }
    }
}