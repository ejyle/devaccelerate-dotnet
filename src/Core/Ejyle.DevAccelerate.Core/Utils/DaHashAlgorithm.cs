// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Utils
{
    public class DaHashAlgorithm
    {
        public static string GenerateHashedString(string plainText, out string salt)
        {
            salt = Guid.NewGuid().ToString();

            var plainTextBytes = Encoding.ASCII.GetBytes(plainText);
            var saltBytes = Encoding.ASCII.GetBytes(salt);

            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

            for (int i = 0; i < plainTextBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainTextBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
            }

            var hashedBytes = algorithm.ComputeHash(plainTextWithSaltBytes);
            return Encoding.ASCII.GetString(hashedBytes);
        }
    }
}
