using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackEyesMvc.Models
{
    public class Brand
    {
        public int Id { get; set; }
       [Required]
        public string BrandName { get; set; }
        public string PhotoUrl { get; set; }
     
    }
}