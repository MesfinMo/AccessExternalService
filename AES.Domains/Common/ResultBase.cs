using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.Common
{
    public abstract class ResultBase
    {
        public IEnumerable<ResultMessage> ResultMessages { get; set; }
    }
}
