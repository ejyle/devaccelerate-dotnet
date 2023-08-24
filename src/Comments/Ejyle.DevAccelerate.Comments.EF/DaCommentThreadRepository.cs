// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Ejyle.DevAccelerate.Comments;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;

namespace Ejyle.DevAccelerate.Comments.EF
{
    public class DaCommentThreadRepository : DaCommentThreadRepository<string, DaCommentThread, DaComment, DaCommentFlag, DaCommentFile, DbContext>
    {
        public DaCommentThreadRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaCommentThreadRepository<TKey, TCommentThread, TComment, TCommentFlag, TCommentFile, TDbContext>
        : DaEntityRepositoryBase<TKey, TCommentThread, TDbContext>, IDaCommentThreadRepository<TKey, TCommentThread, TComment>
        where TKey : IEquatable<TKey>
        where TCommentThread : DaCommentThread<TKey, TComment>
        where TComment : DaComment<TKey, TComment, TCommentFlag, TCommentFile, TCommentThread>
        where TCommentFlag : DaCommentFlag<TKey, TComment>
        where TCommentFile : DaCommentFile<TKey, TComment>
        where TDbContext : DbContext
    {
        public DaCommentThreadRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TCommentThread> CommentThreads { get { return DbContext.Set<TCommentThread>(); } }
        private DbSet<TComment> Comments { get { return DbContext.Set<TComment>(); } }

        public Task CreateAsync(TCommentThread commentThread)
        {
            CommentThreads.Add(commentThread);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TCommentThread commentThread)
        {
            CommentThreads.Remove(commentThread);
            return SaveChangesAsync();
        }

        public Task<TCommentThread> FindByIdAsync(TKey id)
        {
            return CommentThreads.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task CreateCommentAsync(TKey commentThreadId, TComment comment)
        {
            comment.CommentThreadId = commentThreadId;
            Comments.Add(comment);
            return SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TComment>> FindCommentsAsync(TKey commentThreadId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await Comments.Where(m => m.CommentThreadId.Equals(commentThreadId)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = Comments
                .Where(m => m.CommentThreadId.Equals(commentThreadId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TComment>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public Task<List<TCommentThread>> FindByObjectInstanceIdAsync(string objectInstanceId)
        {
            return CommentThreads.Where(m => m.ObjectInstanceId.Equals(objectInstanceId)).ToListAsync();    
        }

        public Task<List<TComment>> FindCommentsAsync(TKey commentThreadId)
        {
            return Comments.Where(m => m.CommentThreadId.Equals(commentThreadId)).ToListAsync();
        }
    }
}
