using LW.DynamicLinq.Filter;
using LW.DynamicLinq.Select;
using LW.DynamicLinq.Sort;
//using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Dynamic.Core;
//using System.Threading.Tasks;
//using TestApp.Models;
//using TestApp.Pagination;

namespace LW.DynamicLinq
{
    /// <summary>
    ///     Sort filter properties
    /// </summary>
    public class SortFilterPageProperties
    {
        public List<SelectFields> SelectFieldList { get; set; }

        public List<FilterFields> FilterFieldList { get; set; }

        public SortFields SortField { get; set; }

        public int StartRecord { get; set; }

        public int RecordCount { get; set; }

        public SortFilterPageProperties()
        {
            SelectFieldList = new List<SelectFields>();
            FilterFieldList = new List<FilterFields>();
            SortField = new SortFields();
        }

        public SortFilterPageProperties(List<SelectFields> selectFieldList, SortFields sortFieldList, List<FilterFields> filterFieldList, int startRecord, int recordCount = 0)
        {
            SelectFieldList = selectFieldList;
            SortField = sortFieldList;
            FilterFieldList = filterFieldList;
            StartRecord = startRecord;
            RecordCount = recordCount;
        }

        public void SetRecordRange(int startRecord, int recordCount)
        {
            StartRecord = startRecord;
            RecordCount = recordCount;
        }
    }

    public class Response<T>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> Data { get; set; }
    }

    //public static class SortFilterPagePropertiesHelper
    //{
    //    public static async Task<Response<TOutput>> SortFilterPage<TEntity, TProperty, TOutput>(
    //        this IIncludableQueryable<TEntity, TProperty> data,
    //        SortFilterPageProperties sortFilterPageProps)
    //    {
    //        var filterResult = FilterService.Filter(data, sortFilterPageProps.FilterFieldList);
    //        var selectResult = SelectService.Select<TEntity, TOutput>(filterResult, sortFilterPageProps.SelectFieldList);
    //        var orderedResult = SortService.Order(selectResult, sortFilterPageProps.SortField);
    //        var paginationResult = PaginationService.Pagination(orderedResult, 3, 10);

    //        var finalResult = await paginationResult.ToDynamicListAsync<TOutput>().ConfigureAwait(false);
    //        return new Response<TOutput>
    //        {
    //            Data = await paginationResult.ToDynamicListAsync<TOutput>(),
    //            TotalRecords = finalResult.Count
    //        };
    //    }
    //}

    //public class Testing
    //{
    //    public string Username { get; set; }
    //    public string SecurityKey { get; set; }
    //    public string FirstName { get; set; }
    //    public ICollection<UserAddress> UserAddress { get; set; }
    //}
}