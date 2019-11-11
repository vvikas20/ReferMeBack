using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Model.common
{
    public class SearchParameter
    {
        public List<SearchFilter> Filters { get; set; }
        public SearchFilter GlobalFilter { get; set; }
        public Sort SortMeta { get; set; }
        public int Page { get; set; } = 1;
        public int Rows { get; set; } = 10000;
        public string DefaultSortField { get; set; }
        public int DefaultSortOrder { get; set; }
    }

    public class SearchFilter
    {
        public string Field { get; set; }
        public string Value { get; set; }
    }

    public class Sort
    {
        public string Field { get; set; }
        public int Order { get; set; }
    }
}
