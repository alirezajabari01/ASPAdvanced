using System.ComponentModel.DataAnnotations;

namespace Shop.Model.Models
{
    public class Product : BaseEntity<int>
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        [Required, StringLength(64)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string ImagePath { get; set; } 
        //private string imagePath;

        //[Required, StringLength(2048)]
        //public string ImagePath
        //{
        //    get { return AppSetting.HttpImagePath + imagePath; }
        //    set { imagePath = value; }
        //}
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
