namespace BlackEyesMvc.Models
{
    public class ProductUnit
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}