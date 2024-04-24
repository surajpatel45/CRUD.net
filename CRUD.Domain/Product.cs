using System.ComponentModel.DataAnnotations;

namespace CRUD.Domain
{
    public class Product
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
