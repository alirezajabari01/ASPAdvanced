using Shop.Application.Contract.Dtos.Users;

namespace Shop.Application.Contract.IServices.Users
{
    public interface IUserService
    {
        string Login(LoginDto dto);
        bool Register(RegisterDto dto);
    }
}
