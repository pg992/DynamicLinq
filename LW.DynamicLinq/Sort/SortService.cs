using System.Linq;
using System.Linq.Dynamic.Core;

namespace LW.DynamicLinq.Sort
{
    public static class SortService
    {
        public static IOrderedQueryable<TEntity> Order<TEntity>(this IQueryable<TEntity> query, SortFields sortFields)
        {
            switch (sortFields.SortOrder)
            {
                case SortOrder.Ascending:
                    return query.OrderBy(sortFields.SortColumnName);
                default:
                    return query.OrderBy($"{sortFields.SortColumnName} descending");
            }
        }
    }
}