// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Exceptions;
using Ejyle.DevAccelerate.Core.Exceptions.Configuration;
using MselExceptionHandling = Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Ejyle.DevAccelerate.Core.ExceptionHandling.Msel
{
    /// <summary>
    /// Represents the Microsoft Enterprise Library Excpetion Handling implementation of the <see cref="IDaExceptionManager"/> interface.
    /// </summary>
    public class MselExceptionManager : IDaExceptionManager
    {
        /// <summary>
        /// Handles an exception with the default exception handling policy.
        /// </summary>
        /// <param name="ex">The exception to be handled.</param>
        public void HandleExpcetion(Exception ex)
        {
            if(ex == null)
            {
                throw new ArgumentNullException(nameof(ex));
            }

            var settings = DaExceptionHandlingConfigurationManager.GetConfiguration();

            string defaultExceptionPolicy = "Default Exception Policy";

            if(settings != null)
            {
                defaultExceptionPolicy = settings.DefaultExceptionPolicy;
            }

            HandleExpcetion(ex, defaultExceptionPolicy);
        }

        /// <summary>
        /// Handles an exception with a given exception handling policy.
        /// </summary>
        /// <param name="ex">The exception to be handled.</param>
        /// <param name="exceptionPolicy">The exception handling policy.</param>
        public void HandleExpcetion(Exception ex, string exceptionPolicy)
        {
            if(ex == null)
            {
                throw new ArgumentNullException(nameof(ex));
            }

            if(string.IsNullOrEmpty(exceptionPolicy))
            {
                throw new ArgumentNullException(nameof(exceptionPolicy));
            }

            int randomValue = new Random().Next();
            string errorId = randomValue.ToString().Substring(0, 4);
            DateTime date = DateTime.Now;
            errorId += string.Format("{0}{1}{2}{3}{4}", date.Day, date.Month, date.Hour, date.Month, date.Second);

            ex.Data.Add("ErrorId", errorId.ToString());

            if (MselExceptionHandling.ExceptionPolicy.HandleException(ex, exceptionPolicy, out Exception exceptionToThrow))
            {
                if (exceptionToThrow != null)
                {
                    throw exceptionToThrow;
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}
