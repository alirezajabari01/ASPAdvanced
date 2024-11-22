using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Model.Models
{
    public class Category : BaseEntity<int>
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        [Required, StringLength(64)]
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
