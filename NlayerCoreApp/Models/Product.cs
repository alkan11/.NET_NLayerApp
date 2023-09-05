using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerCoreApp.Models
{
    public class Product:BaseEntity
    {
        public String? Name  { get; set; }
        public decimal Price  { get; set; }
        public int Stock  { get; set; }
        public int CategoryId  { get; set; }
        public Category? Categorys { get; set; }
        public ProductFeature? ProductFeatures { get; set; }

    }
}
