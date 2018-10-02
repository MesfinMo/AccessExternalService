using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.Common
{
    public class ErrorModel
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
