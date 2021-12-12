// Copyright (c) Microsoft Corporation, Inc. All rights reserved.
// Licensed under the MIT License, Version 2.0. See License.txt in the project root for license information.
// This class was oringinally written by Microsoft as an internal class in its ASP.NET Identity library.
// It has been renamed from its original name AsyncHelper to DaAsyncHelper class.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// A helper class to call asynchronous methods synchronously.
    /// </summary>
    public static class DaAsyncHelper
    {
        private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None,
            TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        /// <summary>
        /// Calls an asynchronous method synchrounously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="func">A reference to an asynchronous method.</param>
        /// <returns>Returns an instance of the generic result type.</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;
            return _myTaskFactory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Calls an asynchronous method synchrounously.
        /// </summary>
        /// <param name="func">A reference to an asynchronous method.</param>
        public static void RunSync(Func<Task> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;

            _myTaskFactory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap().GetAwaiter().GetResult();
        }
    }
}
