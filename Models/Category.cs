﻿using System.Collections.Generic;

namespace BlackEyesMvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int productId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}