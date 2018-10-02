using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.Result
{
    public class ServiceResult<T>
    {
        public IEnumerable<ServiceMessage> ServiceMessages { get; set; }
        public T ResultObject { get; set; }
    }
}
