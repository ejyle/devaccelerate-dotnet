// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using CommandLine;
using Ejyle.DevAccelerate.MultiTenancy.EF;
using Ejyle.DevAccelerate.MultiTenancy.ApiManagement;
using Ejyle.DevAccelerate.MultiTenancy.EF.ApiManagement;

namespace Ejyle.DevAccelerate.Tools.Commands.MultiTenancy
{
    [Verb("createapikey", HelpText = "Creates a DevAccelerate API key.")]
    public class DaCreateApiKeyCommand : DaDatabaseCommand
    {
        [Option('e', "expiry", Required = false, HelpText = "Expiry (in days) of the new api key to be created.")]
        public int? Expiry
        {
            get;
            set;
        }

        public override void Execute()
        {
            EnsureConnectionIsValid();

            Console.WriteLine("Creating an API key...");

            using (var context = new DaMultiTenancyDbContext(GetConnectionString()))
            {
                DateTime? expiryDate = null;

                if (Expiry != null)
                {
                    if(Expiry <= 0 || Expiry > 365)
                    {
                        throw new Exception("Expiry (days) cannot be 0 or less than 0. Must be between 1 and 365.");
                    }

                    expiryDate = DateTime.UtcNow.AddDays((int)Expiry);
                }

                var apiKeyManager = new DaApiKeyManager(new DaApiKeyRepository(context));
                var apiKey = new DaApiKey()
                {
                    IsActive = true,
                    IsExpired = false,
                    ExpiryDateUtc = expiryDate,
                    CreatedDateUtc = DateTime.UtcNow
                };

                var secretKey = apiKeyManager.Create(apiKey);
                Console.WriteLine($"API key created. The API key is {apiKey.ApiKey} and the secret key is {secretKey}. Please copy the secret as it cannot be regnerated if you lose it.");
            }
        }
    }
}
