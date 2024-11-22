using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Model.Models
{
    public abstract class BaseEntity<TKey> where TKey : struct
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Creator = "ali";
            Modifier = "Mahsa";
        }


        public TKey Id { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
