namespace Shop.Model.Models
{
    public class ProductCategory : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } 
    }

    //public class State
    //{
    //    public int Id { get; set; }
    //}
}
