using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.Service
{
    public class SearchResult
    {
        public string SearchTerm { get; set; }
        public string SortOrder { get; set; }
        public int TotalResult { get; set; }
        public int Index { get; set; }

        public int ResultSize { get; set; }

        public List<SearchProduct> SearchProducts { get; set; }
    }
}
