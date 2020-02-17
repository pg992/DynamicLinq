using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace LW.DynamicLinq.Select
{
    public static class SelectService
    {
        public static IQueryable<TOutput> Select<TEntity, TOutput>(this IQueryable<TEntity> query, List<SelectFields> selectFields)
        {
            var str = $"{BuildQuery(selectFields)}";
            return query.Select<TOutput>($"{str}");
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
                var selectedColumn = selectFields[i].SelectColumnName;
                selectedColumn = selectedColumn.Contains(".") ? 
                    $"{selectedColumn} as {string.Join("", selectedColumn.Split("."))}" : selectedColumn;
                if (i == 0)
                {
                    if (selectFields.Count > 1)
                    {
                        
                        qb.Append($"new({selectedColumn},");
                    }
                    else
                    {
                        qb.Append($"new({selectedColumn})");
                    }
                }
                else if (i == selectFields.Count - 1)
                {
                    qb.Append($"{selectedColumn})");
                }
                else
                {
                    qb.Append($"{selectedColumn},");
                }
            }
            return qb.ToString();
        }
    }
}