using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contract.Dtos.Commons
{
    public class ImagePathProvider
    {
        public string ImagePath { get; set; }
        public static string HttpImagePath { get; set; }
    }
}
