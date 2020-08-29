using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackEyesMvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public int price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public ICollection<ProductUnit> ProductUnits { get; set; }

        public int brandId { get; set; }
        public ICollection<Brand> brands { get; set; }
    }
}