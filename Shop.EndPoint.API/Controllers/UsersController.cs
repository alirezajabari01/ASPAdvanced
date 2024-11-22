using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shop.Application.Contract.Dtos.Users;
using Shop.Application.Contract.IServices.Users;

namespace Shop.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UsersController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            string token = userService.Login(dto);
            return Ok(token);
        }

        [HttpPost("[action]")]
        public IActionResult Register(RegisterDto dto)
        {
            userService.Register(dto);
            return Ok();
        }



        [HttpGet("{element}")]
        public IActionResult MemoryCache(string element)
        {
            memoryCache.Set<string>(element, element);

            //var x = memoryCache.Get()
            return Ok();
        }

    }
}
