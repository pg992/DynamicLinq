using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace LW.DynamicLinq.Select
{
    public static class SelectService
    {
        public static IQueryable<TOutput> Select<TEntity, TOutput>(this IQueryable<TEntity> query, List<SelectFields> selectFields)
        {
            return query.Select<TOutput>($"{BuildQuery(selectFields)}");
        }

        public static IQueryable Select<TEntity>(this IQueryable<TEntity> query, List<SelectFields> selectFields)
        {
            return query.Select($"{BuildQuery(selectFields)}");
        }

        private static string BuildQuery(List<SelectFields> selectFields)
        {
            var qb = new StringBuilder();
            for (var i = 0; i < selectFields.Count; i++)
            {
                if (i == 0)
                {
                    if (selectFields.Count > 1)
                    {
                        qb.Append($"new({selectFields[i].SelectColumnName},");
                    }
                    else
                    {
                        qb.Append($"new({selectFields[i].SelectColumnName})");
                    }
                }
                else if (i == selectFields.Count - 1)
                {
                    qb.Append($"{selectFields[i].SelectColumnName})");
                }
                else
                {
                    qb.Append($"{selectFields[i].SelectColumnName},");
                }
            }
            return qb.ToString();
        }
    }
}