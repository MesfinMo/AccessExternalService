using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.WalmartApi
{
    public class ItemRecommendation : Item
    {
        public GiftOptions giftOptions { get; set; }
        public ImageEntity[] imageEntities { get; set; }
        public string offerType { get; set; }
        
    }
}
