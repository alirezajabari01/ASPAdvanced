using System.ComponentModel.DataAnnotations;

namespace Shop.Model.Models
{
    public class ProductHistory : BaseEntity<int>
    {
        [Required, StringLength(64)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
