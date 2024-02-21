using REST_API_NorthwindProject.Models;

namespace REST_API_NorthwindProject.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }

        public virtual CategoryDTO? Category { get; set; }
    }
}
