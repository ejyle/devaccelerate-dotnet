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
    /// Represents the result of an operation on an entity or list of entities.
    /// </summary>
    public class DaEntityResult
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaEntityResult"/> class.
        /// </summary>
        public DaEntityResult()
        {
            IsSuccessful = true;
            Data = null;
            Errors = null;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaEntityResult"/> class.
        /// </summary>
        /// <param name="data">Assigns value to the <see cref="Data"/> property.</param>
        public DaEntityResult(object data)
        {
            IsSuccessful = true;
            Data = data;
            Errors = null;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaEntityResult"/> class.
        /// </summary>
        /// <param name="errors">Assigns value to the <see cref="Errors"/> property.</param>
        public DaEntityResult(IEnumerable<DaError> errors)
        {
            Errors = errors ?? throw new ArgumentNullException(nameof(errors));
            IsSuccessful = false;
            Data = null;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaEntityResult"/> class.
        /// </summary>
        /// <param name="error">Adds an error to the <see cref="Errors"/> property.</param>
        public DaEntityResult(DaError error)
        {
            var e = error ?? throw new ArgumentNullException(nameof(error));
            var errors = new List<DaError>();
            errors.Add(error);
            Errors = errors;
            IsSuccessful = false;
            Data = null;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaEntityResult"/> class.
        /// </summary>
        /// <param name="errors">Assigns a value to the <see cref="Errors"/> property.</param>
        /// <param name="data">Assigns a value to the <see cref="Data"/> property.</param>
        public DaEntityResult(IEnumerable<DaError> errors, object data)
        {
            Errors = errors ?? throw new ArgumentNullException(nameof(errors));
            IsSuccessful = false;
            Data = data;
        }

        /// <summary>
        /// Gets the data associated with the result.
        /// </summary>
        public object Data
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a list of errors in case the result is not successful.
        /// </summary>
        public IEnumerable<DaError> Errors
        {
            get;
            private set;
        }

        /// <summary>
        /// Determines if the result is successful or not.
        /// </summary>
        public bool IsSuccessful
        {
            get;
            private set;
        }
    }
}
