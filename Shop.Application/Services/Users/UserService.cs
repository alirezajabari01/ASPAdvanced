using Microsoft.AspNetCore.Identity;
using Shop.Application.Contract.Dtos.Users;
using Shop.Application.Contract.IServices.Users;
using Shop.InfraStructure.Contexts;
using Shop.Model.Models.IdentityModels;

namespace Shop.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ITokenHandler tokenHandler;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;
        public UserService(ITokenHandler tokenHandler, UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            this.tokenHandler = tokenHandler;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
        }

        public string Login(LoginDto dto)
        {
            var user = userManager.FindByNameAsync(dto.UserName).GetAwaiter().GetResult();

            if (userManager.CheckPasswordAsync(user, dto.Password).GetAwaiter().GetResult())
            {
                var roles = userManager.GetRolesAsync(user).
                    GetAwaiter().GetResult().ToArray();
                return tokenHandler.GenerateToken(user.Id, roles);
            }

            return "";
        }

        //public bool Register(RegisterDto dto)
        //{
        //    var user = new IdentityUser(dto.UserName);
        //    user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);
        //    userManager.CreateAsync(user).GetAwaiter().GetResult();
        //    var result = userManager.AddToRoleAsync(user, RoleSeedData.Name).GetAwaiter().GetResult();
        //    return result.Succeeded;
        //}

        public bool Register(RegisterDto dto)
        {
            var user = new ApplicationUser(dto.UserName);
            //user.UserName = dto.UserName;
            user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);
            var userRole = new ApplicationUserRole()
            {
                //Role = new ApplicationRole(RoleSeedData.Name)
                //{
                //    ConcurrencyStamp = RoleSeedData.ConcurrencyStamp,
                //    Id = RoleSeedData.RoleId,
                //    NormalizedName = RoleSeedData.NormalizedName
                //},
                RoleId= RoleSeedData.RoleId,
                //User = user,
                UserId=user.Id
            };

            user.ApplicationUserRoles.Add(userRole);
            var SavedUser = userManager.CreateAsync(user).GetAwaiter().GetResult();

            return SavedUser != null;
        }
    }
}
