using System;
using System.Collections.Generic;

namespace BlackEyesMvc.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}