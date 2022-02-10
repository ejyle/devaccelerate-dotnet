// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core
{
    public class DaOperationResult : DaOperationResult<DaOperationError>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaOperationResult"/> class.
        /// </summary>
        /// <remarks>The <see cref="IsSuccess"/> property is set to True.</remarks>
        public DaOperationResult()
            : base()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaOperationResult"/> class.
        /// </summary>
        /// <param name="errors">Sets the value of the <see cref="Errors"/> property.</param>
        /// <remarks>The <see cref="IsSuccess"/> property is set to False.</remarks>
        /// <exception cref="ArgumentNullException">Thrown if errors is null or count is 0.</exception>
        public DaOperationResult(IEnumerable<DaOperationError> errors)
            : base(errors)
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaOperationResult"/> class.
        /// </summary>
        /// <param name="error">Adds the value to the <see cref="Errors"/> property.</param>
        /// <remarks>The <see cref="IsSuccess"/> property is set to False.</remarks>
        /// <exception cref="ArgumentNullException">Thrown if error is null.</exception>
        public DaOperationResult(DaOperationError error)
            : base(error)
        { }
    }

    /// <summary>
    /// Represents the result of an operation.
    /// </summary>
    /// <typeparam name="TError"></typeparam>
    /// <remarks>Either <see cref="IsSuccess"/> property is True or the <see cref="Errors"/> property has one or more errors.</remarks>
    public class DaOperationResult<TError>
        where TError : DaOperationError
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaOperationResult{TError}"/> class.
        /// </summary>
        /// <remarks>The <see cref="IsSuccess"/> property is set to True.</remarks>
        public DaOperationResult()
        {
            IsSuccess = true;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaOperationResult{TError}"/> class.
        /// </summary>
        /// <param name="errors">Sets the value of the <see cref="Errors"/> property.</param>
        /// <remarks>The <see cref="IsSuccess"/> property is set to False.</remarks>
        /// <exception cref="ArgumentNullException">Thrown if errors is null or count is 0.</exception>
        public DaOperationResult(IEnumerable<DaOperationError> errors)
        {
            if (errors == null || errors.Count() == 0)
            {
                throw new ArgumentNullException(nameof(errors));
            }

            IsSuccess = false;
            Errors = errors;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaOperationResult{TError}"/> class.
        /// </summary>
        /// <param name="error">Adds the value to the <see cref="Errors"/> property.</param>
        /// <remarks>The <see cref="IsSuccess"/> property is set to False.</remarks>
        /// <exception cref="ArgumentNullException">Thrown if error is null.</exception>
        public DaOperationResult(DaOperationError error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            IsSuccess = false;

            var errors = new List<DaOperationError>();
            errors.Add(error);

            Errors = errors;
        }

        /// <summary>
        /// Gets a list of errors encountered during the execution of an operation.
        /// </summary>
        public IEnumerable<DaOperationError> Errors
        {
            get;
            private set;
        }

        /// <summary>
        /// Determines if the execution of the operation was successful without any errors.
        /// </summary>
        public bool IsSuccess { get; private set; }
    }
}
