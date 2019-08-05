namespace LW.DynamicLinq.Filter
{
    public class FilterFields
    {
        /// <summary>
        ///     Gets or sets the filter column name
        /// </summary>
        public string FilterColumnName { get; set; }

        /// <summary>
        ///     Gets or sets the filter value
        /// </summary>
        public string FilterValue { get; set; }

        /// <summary>
        ///     Gets or sets the filter value
        /// </summary>
        public FilterType FilterTypeVal { get; set; }
    }
}