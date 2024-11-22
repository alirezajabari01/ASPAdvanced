using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Application.Contract.IServices.Users;
using Shop.EndPoint.API.Exceptions;
using System.Diagnostics;

namespace Shop.EndPoint.API.Filters
{
    public class SecurityFilter : ActionFilterAttribute
    {
        public SecurityFilter(string input)
        {
            Input = input;
        }

        public string Input { get; private set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = GetRawToken(context);

            var tokenHandler = context.HttpContext.RequestServices.GetRequiredService<ITokenHandler>();

            var claims = tokenHandler.ValidateToken(token);

            if (claims.Any(x => x.Type == "Roles" && x.Value == Input))
            {
                var userContext = context.HttpContext.RequestServices.GetRequiredService<IUserContext>();

                userContext.UserId = claims.First(x => x.Type == "UserId").Value;
                return;
            }

            throw new DontAllowAccessException();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("After");
        }

        private static string GetRawToken(ActionExecutingContext context)
        {
            string? authorizationHeader
                = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
                throw new DontAllowAccessException();

            if (!authorizationHeader.StartsWith("Bearer "))
                throw new DontAllowAccessException();

            return authorizationHeader.Replace("Bearer ", "");
        }
    }
}
