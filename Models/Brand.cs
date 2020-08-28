using System.Collections.Generic;

namespace BlackEyesMvc.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Photo { get; set; }
        public int productId { get; set; }

        public ICollection<ProductBrand> ProductBrands { get; set; }
    }
}