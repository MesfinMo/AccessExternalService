using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.Service
{
    public class Recommendation : Product
    {
        public string OfferType { get; set; }
        public bool IsTwoDayShippingEligible { get; set; }
    }
}
