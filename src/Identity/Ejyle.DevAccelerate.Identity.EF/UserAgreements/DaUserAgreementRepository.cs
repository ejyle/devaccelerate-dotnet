// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Identity.UserAgreements;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Identity.EF.UserAgreements
{
    public class DaUserAgreementRepository : DaUserAgreementRepository<string, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction, DbContext>
    {
        public DaUserAgreementRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction, TDbContext>
        : DaEntityRepositoryBase<TKey, TUserAgreement, TDbContext>, IDaUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>
        where TKey : IEquatable<TKey>
        where TUserAgreement : DaUserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
        where TDbContext : DbContext
    {
        public DaUserAgreementRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TUserAgreement> UserAgreements { get { return DbContext.Set<TUserAgreement>(); } }
        private DbSet<TUserAgreementVersion> UserAgreementVersions { get { return DbContext.Set<TUserAgreementVersion>(); } }
        private DbSet<TUserAgreementVersionAction> UserAgreementVersionActions { get { return DbContext.Set<TUserAgreementVersionAction>(); } }

        public Task CreateAsync(TUserAgreement userAgreement)
        {
            UserAgreements.Add(userAgreement);
            return SaveChangesAsync();
        }

        public Task CreateAsync(TUserAgreementVersionAction userAgreementVersionAction)
        {
            UserAgreementVersionActions.Add(userAgreementVersionAction);
            return SaveChangesAsync();
        }

        public Task<TUserAgreement> FindByIdAsync(TKey id)
        {
            return UserAgreements
                .Where(m => m.Id.Equals(id))
                .Include(m => m.UserAgreementVersions)
                .SingleOrDefaultAsync();
        }

        public Task<TUserAgreement> FindByKeyAsync(string key)
        {
            return UserAgreements
                .Where(m => m.Key == key)
                .Include(m => m.UserAgreementVersions)
                .SingleOrDefaultAsync();
        }

        public Task<TUserAgreement> FindByVersionIdAsync(TKey userAgreementVersionId)
        {
            return UserAgreements
                .Where(m => m.UserAgreementVersions
                .Any(n => n.Id.Equals(userAgreementVersionId)))
                .Include(m => m.UserAgreementVersions)
                .SingleOrDefaultAsync();
        }

        public Task<TUserAgreementVersion> FindCurrentUserAgreementVersionAsync(string key)
        {
            return UserAgreementVersions
                .Where(m => m.UserAgreement.Key == key && m.IsCurrent == true)
                .Include(m => m.UserAgreement)
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TUserAgreement userAgreement)
        {
            DbContext.Entry<TUserAgreement>(userAgreement).State = EntityState.Modified;
            return SaveChangesAsync();
        }
    }
}
