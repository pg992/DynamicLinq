﻿using System.Linq;

namespace LW.DynamicLinq.Pagination
{
    public static class PaginationService
    {
        public static IQueryable<TEntity> Pagination<TEntity>(this IQueryable<TEntity> query, int startRecord, int recordCount)
        {
            return query.Skip(startRecord).Take(recordCount);
        }
    }
}