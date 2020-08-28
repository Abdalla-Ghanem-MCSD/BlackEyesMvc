using System;
using System.Collections.Generic;

namespace BlackEyesMvc.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int orderId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}