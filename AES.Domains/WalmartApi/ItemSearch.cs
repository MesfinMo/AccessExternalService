using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.WalmartApi
{
    public class ItemSearch
    {
        public string query { get; set; }
        public string sort { get; set; }
        public string responseGroup { get; set; }
        public int totalResults { get; set; }
        public int start { get; set; }
        public int numItems { get; set; }
        public Item[] items { get; set; }
    }
}
