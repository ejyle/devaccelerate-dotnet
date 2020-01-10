// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Profiles.Addresses;

namespace Ejyle.DevAccelerate.Profiles.EF.Addresses
{
    public class DaAddressProfileRepository : DaAddressProfileRepository<int, int?, DaAddressProfile, DaUserAddress, DbContext>
    {
        public DaAddressProfileRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaAddressProfileRepository<TKey, TNullableKey, TAddressProfile, TUserAddress, TDbContext>
        : DaEntityRepositoryBase<TKey, TAddressProfile, TDbContext>, IDaAddressProfileRepository<TKey, TNullableKey, TAddressProfile>
        where TKey : IEquatable<TKey>
        where TAddressProfile : DaAddressProfile<TKey, TNullableKey, TUserAddress>
        where TUserAddress : DaUserAddress<TKey, TNullableKey, TAddressProfile>
        where TDbContext : DbContext
    {
        public DaAddressProfileRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TAddressProfile> UserProfiles { get { return DbContext.Set<TAddressProfile>(); } }
        public Task CreateAsync(TAddressProfile userProfile)
        {
            UserProfiles.Add(userProfile);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TAddressProfile userProfile)
        {
            UserProfiles.Remove(userProfile);
            return SaveChangesAsync();
        }

        public Task<TAddressProfile> FindByIdAsync(TKey id)
        {
            return UserProfiles.Where(m => m.Id.Equals(id)).Include(m => m.UserAddresses).SingleOrDefaultAsync();
        }

        public Task<List<TAddressProfile>> FindByTenantIdAsync(TKey tenantId)
        {
            return UserProfiles.Where(m => m.UserAddresses.Any(n => n.TenantId.Equals(tenantId))).Include(m => m.UserAddresses).ToListAsync();
        }

        public Task<List<TAddressProfile>> FindByUserIdAsync(TKey userId)
        {
            return UserProfiles.Where(m => m.UserAddresses.Any(n => n.UserId.Equals(userId))).Include(m => m.UserAddresses).ToListAsync();
        }

        public Task UpdateAsync(TAddressProfile userProfile)
        {
            DbContext.Entry<TAddressProfile>(userProfile).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
