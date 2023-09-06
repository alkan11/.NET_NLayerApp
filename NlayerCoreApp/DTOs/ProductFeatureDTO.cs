using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerCoreApp.DTOs
{
    public class ProductFeatureDTO:BaseDTO
    {

        public string? Color { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public int ProductId { get; set; }
    }
}
