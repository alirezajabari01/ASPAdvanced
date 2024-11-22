using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Application.Contract.Dtos.Products;
using Shop.Application.Contract.Dtos.Quantities;
using Shop.Application.Contract.IServices.Products;
using Shop.Application.Contract.IServices.Users;
using Shop.InfraStructure.IRepositories;
using Shop.Model.Models;

namespace Shop.Application.Services.Products
{
    public class ProductUserService : IProductUserService
    {
        private readonly ILogger<ProductUserService> logger;
        private readonly IRepository<Product, int> repository;
        private readonly IInventoryExternalService inventoryExternalService;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public ProductUserService(IRepository<Product, int> repository,
            IMapper mapper,
            IInventoryExternalService inventoryExternalService,
            IUserContext userContext
, ILogger<ProductUserService> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.inventoryExternalService = inventoryExternalService;
            this.userContext = userContext;
            this.logger = logger;
        }

        public List<ProductDto> Get()
        {
            var products = repository.GetAll().ToList();
            var mapped = mapper.Map<List<ProductDto>>(products);
            return mapped;
        }

        public ProductDto GetById(int id)
        {
            logger.LogInformation(id.ToString());
            var product = repository.GetById(id);
            return mapper.Map<ProductDto>(product);
        }

        public int GetQuantity(QuantityRequestDto dto)
        {
            var userid = userContext.UserId;
            return inventoryExternalService.GetQuantity(dto);
        }

        public PagingModel<List<ProductDto>> GetWithFilter(ProductFilterDto dto)
        {
            //var query = repository.GetAll()
            //   .Where(x => x.Name.Contains(dto.Name))
            //   .Where(x => dto.StartPrice == default || x.Price >= dto.StartPrice)
            //   .Where(x => dto.EndPrice == default || x.Price <= dto.EndPrice)
            //   .SelectMany(x => x.ProductCategories
            //        .Where(pc => dto.CategoryIds.Contains(pc.CategoryId)))
            //   .Select(pc => pc.Product);

            //var linqQuery=from product in repository.GetAll()
            //              select{
            //    select{ product}
            //}


            var query = repository.GetAll().Include(x => x.ProductCategories
              .Where(pc => dto.CategoryIds.Contains(pc.CategoryId)))
              .Where(x => x.Name.Contains(dto.Name))
              .Where(x => dto.StartPrice == default || x.Price >= dto.StartPrice)
              .Where(x => dto.EndPrice == default || x.Price <= dto.EndPrice);



            var products = query
               .Skip(dto.Skip)
               .Take(dto.Take)
               .ToList();

            var mapped = mapper.Map<List<ProductDto>>(products);
            return new PagingModel<List<ProductDto>>(mapped, query.Count());


        }
    }
}
