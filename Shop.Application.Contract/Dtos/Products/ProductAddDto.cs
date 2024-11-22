using Microsoft.AspNetCore.Http;

namespace Shop.Application.Contract.Dtos.Products
{
    public record ProductAddDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile File { get; set; }
    }

    public record ProductFilterDto
    {
        public string Name { get; set; } = "";
        public decimal StartPrice { get; set; } = 0;
        public decimal EndPrice { get; set; } = 0;
        public int Take { get; set; } = 50;
        public int Skip { get; set; } = 0;

        public ICollection<int?> CategoryIds { get; set; }
    }

    public class PagingModel<T> where T :class
    {
        public PagingModel(T data, long count) 
        {
            Data = data;
            Count = count;
        }

        public T Data { get; set; } = null!;
        public long Count { get; set; }

        //public int Quantity { get; set; }
    }
}
