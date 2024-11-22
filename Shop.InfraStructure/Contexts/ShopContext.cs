using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Model.Models;
using Shop.Model.Models.IdentityModels;

namespace Shop.InfraStructure.Contexts
{
    public class ShopContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ShopContext(DbContextOptions<ShopContext> option) : base(option) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductHistory> ProductHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasKey(x => x.Id);
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.ApplicationUserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<ApplicationRole>().HasKey(x => x.Id);
            modelBuilder.Entity<ApplicationRole>().HasMany(x => x.ApplicationUserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(x => x.User);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(x => x.Role);



            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            GenerateRoleData(modelBuilder);
        }

        private static void GenerateRoleData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole
            {
                Id = RoleSeedData.RoleId,
                Name = RoleSeedData.Name,
                NormalizedName = RoleSeedData.NormalizedName,
                ConcurrencyStamp = RoleSeedData.ConcurrencyStamp
            },
            new IdentityRole
            {
                Id = RoleSeedData.SupportRoleId,
                Name = RoleSeedData.SupportName,
                NormalizedName = RoleSeedData.SupportNormalizedName,
                ConcurrencyStamp = RoleSeedData.SupportConcurrencyStamp
            });
        }
    }
}
