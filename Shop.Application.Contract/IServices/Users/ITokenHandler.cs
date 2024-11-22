using System.Security.Claims;

namespace Shop.Application.Contract.IServices.Users
{
    public interface ITokenHandler
    {
        string GenerateToken(string userId, params string[] roles);

        List<Claim> ValidateToken(string token);
    }
}
