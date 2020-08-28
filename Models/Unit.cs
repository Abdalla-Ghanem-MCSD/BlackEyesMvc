using System.Collections.Generic;

namespace BlackEyesMvc.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public ICollection<ProductUnit> ProductUnits { get; set; }
    }
}