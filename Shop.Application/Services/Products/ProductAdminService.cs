using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shop.Application.Contract.Dtos.Commons;
using Shop.Application.Contract.Dtos.Products;
using Shop.Application.Contract.IServices.Products;
using Shop.Application.UnitOfWorks;
using Shop.InfraStructure.IRepositories;
using Shop.Model.Models;

namespace Shop.Application.Services.Products
{
    public class ProductAdminService : IProductAdminService
    {
        private readonly IRepository<Product, int> repository;
        private readonly IRepository<Category, int> repository2;
        private readonly IMapper mapper;
        private readonly string imagePath;

        public ProductAdminService(IRepository<Product, int> repository, IOptions<ImagePathProvider> options, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            imagePath = options.Value.ImagePath;
        }

        [UnitOfWork]
        public bool Add(ProductAddDto dto)
        {
            bool result = false;
            //SaveFile(dto.File);

            var mapped = mapper.Map<Product>(dto);
            var rowAffected = repository.Add(mapped);

            if (rowAffected > 0)
                result = true;

            return result;
        }

        private void SaveFile(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);

            File.WriteAllBytes($"{imagePath}{file.FileName}", memoryStream.ToArray());
        }

        public void GetPaging(int take, int skip)
        {
            var result = repository.GetAll().Skip(skip).Take(take).ToList();
            var count= repository.GetAll().Count();
        }

        public void GetTest()
        {
            var result = repository.GetAll().Include(x => x.ProductCategories).ThenInclude(pc => pc.Category).ToList();
        }
    }
}
