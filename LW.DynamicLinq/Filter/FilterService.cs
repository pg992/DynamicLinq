using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace LW.DynamicLinq.Filter
{
    public static class FilterService
    {
        public static IQueryable<TEntity> Filter<TEntity, TProperty>(this IIncludableQueryable<TEntity, TProperty> query, List<FilterFields> fields)
        {
            IQueryable<TEntity> dynamicQuery = query;
            foreach (var filters in fields)
            {
                if (string.IsNullOrWhiteSpace(filters.FilterTableName))
                {
                    dynamicQuery = dynamicQuery.Where($"{filters.FilterColumnName}{CalculateExpression(filters.FilterTypeVal.Value)}", filters.FilterValue);
                }
                else
                {
                    dynamicQuery = dynamicQuery.Where($"{filters.FilterTableName}{CalculateNestedExpression(filters.FilterTypeVal.Value, filters.FilterColumnName)}", filters.FilterValue);
                }
            }

            return dynamicQuery;
        }

        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, List<FilterFields> fields)
        {
            foreach (var filters in fields)
            {
                if (string.IsNullOrWhiteSpace(filters.FilterTableName))
                {
                    query = query.Where($"{filters.FilterColumnName}{CalculateExpression(filters.FilterTypeVal.Value)}", filters.FilterValue);
                }
                else
                {
                    query = query.Where($"{filters.FilterTableName}{CalculateNestedExpression(filters.FilterTypeVal.Value, filters.FilterColumnName)}", filters.FilterValue);
                }
            }

            return query;
        }

        private static string CalculateExpression(FilterType type)
        {
            switch (type)
            {
                case FilterType.Contains:
                    return ".ToLower().Contains(@0.ToLower())";
                case FilterType.StartsWith:
                    return ".ToLower().StartsWith(@0.ToLower())";
                case FilterType.EndsWith:
                    return ".ToLower().EndsWith(@0.ToLower())";
                case FilterType.Equals:
                    return "=@0";
                default:
                    return "=@0";
            }
        }

        private static string CalculateNestedExpression(FilterType type, string paramName)
        {
            return $".Any({paramName}{CalculateExpression(type)})";
        }
    }
}