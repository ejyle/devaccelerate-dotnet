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
    /// Manages the execution of initializers as a queue.
    /// </summary>
    public static class DaInitializationManager
    {
        private static Queue<IDaInitializer> _initializers = new Queue<IDaInitializer>();
        private static bool _Executed = false;

        /// <summary>
        /// Executes each added initializer one-by-one on first-in-first-out basis.
        /// </summary>
        public static void Execute()
        {
            if(_Executed)
            {
                throw new InvalidOperationException("The DevAccelerate bootstrapping has already been completed.");
            }

            while (_initializers.Count >= 1)
            {
                var strategy = _initializers.Dequeue();

                if (strategy != null)
                {
                    strategy.Initialize();
                }
            }

            _Executed = true;
        }

        /// <summary>
        /// Adds an initializer to the queue for execution.
        /// </summary>
        /// <param name="initializer">The initializer to be added.</param>
        public static void AddModuleInitializer(IDaInitializer initializer)
        {
            _initializers.Enqueue(initializer);
        }
    }
}
