
using Microsoft.AspNetCore.Identity;

namespace Shop.Model.Models.IdentityModels
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        }
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
