using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Domains.WalmartApi
{
    public class ImageEntity
    {
        public string thumbnailImage { get; set; }
        public string mediumImage { get; set; }
        public string largeImage { get; set; }
        public string entityType { get; set; }
    }
}
