using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace HSE.DAL.ViewModels
{
    public class DataTableParamsModel
    {
        public class JqueryDataTablesResult<T>
        {
            /// <summary>
            /// The draw counter that this object is a response to - from the draw parameter sent as part of the data request.
            /// Note that it is strongly recommended for security reasons that you cast this parameter to an integer, rather than simply echoing back to the client what it sent in the draw parameter, in order to prevent Cross Site Scripting (XSS) attacks.
            /// </summary>
            [JsonProperty(PropertyName = "draw")]
            [JsonPropertyName("draw")]
            public int Draw { get; set; }

            /// <summary>
            /// Total records, before filtering (i.e. the total number of records in the database)
            /// </summary>
            [JsonProperty(PropertyName = "recordsTotal")]
            [JsonPropertyName("recordsTotal")]
            public int RecordsTotal { get; set; }

            /// <summary>
            /// Total records, after filtering (i.e. the total number of records after filtering has been applied - not just the number of records being returned for this page of data).
            /// </summary>
            [JsonProperty(PropertyName = "recordsFiltered")]
            [JsonPropertyName("recordsFiltered")]
            public int RecordsFiltered { get; set; }

            /// <summary>
            /// The data to be displayed in the table.
            /// This is an array of data source objects, one for each row, which will be used by DataTables.
            /// Note that this parameter's name can be changed using the ajaxDT option's dataSrc property.
            /// </summary>
            [JsonProperty(PropertyName = "data")]
            [JsonPropertyName("data")]
            public IEnumerable<T> Data { get; set; }
        }

        /// <summary>
        /// The additional columns that you can send to jQuery DataTables for automatic processing.
        /// </summary>
        public abstract class DtRow
        {
            /// <summary>
            /// Set the ID property of the dt-tag tr node to this value
            /// </summary>
            public virtual string DtRowId => null;

            /// <summary>
            /// Add this class to the dt-tag tr node
            /// </summary>
            public virtual string DtRowClass => null;

            /// <summary>
            /// Add this data property to the row's dt-tag tr node allowing abstract data to be added to the node, using the HTML5 data-* attributes.
            /// This uses the jQuery data() method to set the data, which can also then be used for later retrieval (for example on a click event).
            /// </summary>
            public virtual object DtRowData => null;
        }

        /// <summary>
        /// The parameters sent by jQuery DataTables in AJAX queries.
        /// </summary>
        public class JqueryDataTablesParameters
        {
            /// <summary>
            /// Draw counter.
            /// This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return out of sequence).
            /// This is used as part of the draw return parameter (see below).
            /// </summary>
            public int Draw { get; set; }

            /// <summary>
            /// An array defining all columns in the table.
            /// </summary>
            public DtColumn[] Columns { get; set; }

            /// <summary>
            /// An array defining how many columns are being ordering upon - i.e. if the array length is 1, then a single column sort is being performed, otherwise a multi-column sort is being performed.
            /// </summary>
            public DtOrder[] Order { get; set; }

            /// <summary>
            /// Paging first record indicator.
            /// This is the start point in the current data set (0 index based - i.e. 0 is the first record).
            /// </summary>
            public int Start { get; set; }

            /// <summary>
            /// Number of records that the table can display in the current draw.
            /// It is expected that the number of records returned will be equal to this number, unless the server has fewer records to return.
            /// Note that this can be -1 to indicate that all records should be returned (although that negates any benefits of server-side processing!)
            /// </summary>
            public int Length { get; set; }

            /// <summary>
            /// Global search value. To be applied to all columns which have searchable as true.
            /// </summary>
            public DtSearch Search { get; set; }

            /// <summary>
            /// Custom column that is used to further sort on the first Order column.
            /// </summary>
            public string SortOrder => Columns != null && Order != null && Order.Length > 0
                        ? (Columns[Order[0].Column].Data + (Order[0].Dir == DtOrderDir.Desc ? " " + Order[0].Dir : string.Empty))
                        : null;

            public string SortingAscColumns { get; set; }
            public string SortingDescColumns { get; set; }

            /// <summary>
            /// For Posting Additional Parameters to Server
            /// </summary>
            public IEnumerable<string> AdditionalValues { get; set; }

        }

        /// <summary>
        /// A jQuery DataTables column.
        /// </summary>
        public class DtColumn
        {
            /// <summary>
            /// Column's data source, as defined by columns.data.
            /// </summary>
            public string Data { get; set; }

            /// <summary>
            /// Column's name, as defined by columns.name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Flag to indicate if this column is searchable (true) or not (false). This is controlled by columns.searchable.
            /// </summary>
            public bool Searchable { get; set; }

            /// <summary>
            /// Flag to indicate if this column is orderable (true) or not (false). This is controlled by columns.orderable.
            /// </summary>
            public bool Orderable { get; set; }

            /// <summary>
            /// Specific search value.
            /// </summary>
            public DtSearch Search { get; set; }
        }

        /// <summary>
        /// An order, as sent by jQuery DataTables when doing AJAX queries.
        /// </summary>
        public class DtOrder
        {
            /// <summary>
            /// Column to which ordering should be applied.
            /// This is an index reference to the columns array of information that is also submitted to the server.
            /// </summary>
            public int Column { get; set; }

            /// <summary>
            /// Ordering direction for this column.
            /// It will be dt-string asc or dt-string desc to indicate ascending ordering or descending ordering, respectively.
            /// </summary>
            public DtOrderDir Dir { get; set; }
        }

        /// <summary>
        /// Sort orders of jQuery DataTables.
        /// </summary>
        public enum DtOrderDir
        {
            Asc,
            Desc
        }

        /// <summary>
        /// A search, as sent by jQuery DataTables when doing AJAX queries.
        /// </summary>
        public class DtSearch
        {
            /// <summary>
            /// Global search value. To be applied to all columns which have searchable as true.
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// true if the global filter should be treated as a regular expression for advanced searching, false otherwise.
            /// Note that normally server-side processing scripts will not perform regular expression searching for performance reasons on large data sets, but it is technically possible and at the discretion of your script.
            /// </summary>
            public bool Regex { get; set; }
        }
    }

    public class JqueryDataTablesBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            Microsoft.AspNetCore.Http.IQueryCollection allValues = bindingContext.HttpContext.Request.Query;

            // Retrieve request data
            int draw = Convert.ToInt32(allValues.FirstOrDefault(a => a.Key == "draw").Value);
            int start = Convert.ToInt32(allValues.FirstOrDefault(a => a.Key == "start").Value);
            int length = Convert.ToInt32(allValues.FirstOrDefault(a => a.Key == "length").Value);

            string sortingDescColumns = allValues.FirstOrDefault(a => a.Key == "sortingDescColumns").Value;
            string sortingAscColumns = allValues.FirstOrDefault(a => a.Key == "sortingAscColumns").Value;

            // Search
            DataTableParamsModel.DtSearch search = new DataTableParamsModel.DtSearch
            {
                Value = allValues.FirstOrDefault(a => a.Key == "search[value]").Value,
                Regex = Convert.ToBoolean(allValues.FirstOrDefault(a => a.Key == "search[regex]").Value)
            };

            // Order
            int o = 0;
            List<DataTableParamsModel.DtOrder> order = new List<DataTableParamsModel.DtOrder>();
            while (allValues.Any(a => a.Key == "order[" + o + "][column]"))
            {
                Enum.TryParse(allValues.FirstOrDefault(a => a.Key == "order[" + o + "][dir]").Value.ToString().ToUpperInvariant(),
                    out DataTableParamsModel.DtOrderDir dir);

                order.Add(new DataTableParamsModel.DtOrder
                {
                    Column = Convert.ToInt32(allValues.FirstOrDefault(a => a.Key == "order[" + o + "][column]").Value),
                    Dir = dir
                });
                o++;
            }

            // Columns
            int c = 0;
            List<DataTableParamsModel.DtColumn> columns = new List<DataTableParamsModel.DtColumn>();
            while (allValues.Any(a => a.Key == "columns[" + c + "][name]"))
            {
                columns.Add(new DataTableParamsModel.DtColumn
                {
                    Data = allValues.FirstOrDefault(a => a.Key == "columns[" + c + "][data]").Value,
                    Name = allValues.FirstOrDefault(a => a.Key == "columns[" + c + "][name]").Value,
                    Orderable = Convert.ToBoolean(allValues.FirstOrDefault(a => a.Key == "columns[" + c + "][orderable]").Value),
                    Searchable = Convert.ToBoolean(allValues.FirstOrDefault(a => a.Key == "columns[" + c + "][searchable]").Value),
                    Search = new DataTableParamsModel.DtSearch
                    {
                        Value = allValues.FirstOrDefault(a => a.Key == "columns[" + c + "][search][value]").Value,
                        Regex = Convert.ToBoolean(allValues.FirstOrDefault(a => a.Key == "columns[" + c + "][search][regex]").Value)
                    }
                });
                c++;
            }

            // Additional Values
            int p = 0;
            List<string> additionalValues = new List<string>();
            while (allValues.Any(a => a.Key == "additionalValues[" + p + "]"))
            {
                additionalValues.Add(allValues.FirstOrDefault(a => a.Key == "additionalValues[" + p + "]").Value);
                p++;
            }

            DataTableParamsModel.JqueryDataTablesParameters model = new DataTableParamsModel.JqueryDataTablesParameters
            {
                Draw = draw,
                Start = start,
                Length = length,
                Search = search,
                Order = order.ToArray(),
                Columns = columns.ToArray(),
                AdditionalValues = additionalValues.ToArray(),
                SortingAscColumns = sortingAscColumns,
                SortingDescColumns = sortingDescColumns
            };

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
