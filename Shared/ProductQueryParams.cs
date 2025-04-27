using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParams
    {
        private const int maxPageSize = 10;
        private const int defaultpageSize = 5;
        public int? TypeId { get; set; } 
        public int? BrandId { get; set; } 
        public ProductSortingOptions sortingOption { get; set; } 
        public string? searchValue { get; set; }
        public int PageIndex { get; set; } = 1;

        private int pageSize = defaultpageSize;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > maxPageSize ? maxPageSize : value; }
        }

    }
}
