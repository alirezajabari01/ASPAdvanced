using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contract.Dtos.Products;
using Shop.Application.Contract.Dtos.Quantities;
using Shop.Application.Contract.IServices.Products;
using Shop.EndPoint.API.Filters;

namespace Shop.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductUserService productUserService;
        private readonly IProductAdminService productAdminService;

        public ProductsController(IProductUserService productUserService, IProductAdminService productAdminService)
        {
            this.productUserService = productUserService;
            this.productAdminService = productAdminService;
        }

        [SecurityFilter("User")]
        [HttpGet("Quantity")]
        public IActionResult GetQuantity()
        {
            return Ok(productUserService.GetQuantity(new QuantityRequestDto
            {
                UserId = 10,
                Product = "mobile",
                Venture = "Product"
            }));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(productUserService.Get());
        }

        [AllowAnonymous]
        [HttpPost("GetWithFilter")]
        public IActionResult Get(ProductFilterDto dto)
        {
            return Ok(productUserService.GetWithFilter(dto));
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult Get([FromQuery] string test = null)
        //{
        //    return Ok(productUserService.Get());
        //}

        //[AllowAnonymous]
        //[HttpGet("{take}/{skip}/{phrase?}/{sort?}")]
        //public IActionResult Get([FromRoute] int take, int skip, string phrase = null)
        //{
        //    return Ok(productUserService.Get());
        //}

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(productUserService.GetById(id));
        }

        // [Authorize("UserPolicy")]
        [HttpPost]
        public IActionResult Add([FromForm] ProductAddDto dto)
        {
            productAdminService.Add(dto);
            return Created("", dto);
        }

        [Authorize("UserPolicy")]
        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
