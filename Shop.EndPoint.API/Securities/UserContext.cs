using Shop.Application.Contract.IServices.Users;

namespace Shop.EndPoint.API.Securities
{
    public class UserContext: IUserContext
    {
        public string UserId { get; set; }
    }
}
