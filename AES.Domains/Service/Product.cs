using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.Service
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ThumbnailUri { get; set; }
        public string MediumThumbnailUri { get; set; }
        public string LargeImageUri { get; set; }
        public string TwoDayShipping { get; set; }
    }
}
