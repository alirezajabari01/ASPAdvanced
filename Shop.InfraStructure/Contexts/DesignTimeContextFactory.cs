//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Shop.InfraStructure.Contexts
//{
//    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ShopContext>
//    {
//        public ShopContext CreateDbContext(string[] args)
//        {
//            var builder = new DbContextOptionsBuilder<ShopContext>();
//            builder.UseSqlServer("data source=.; initial catalog=BamdadFallShopDB; user id=sa;password=123;");

//            return new ShopContext(builder.Options);
//        }
//    }
//}
