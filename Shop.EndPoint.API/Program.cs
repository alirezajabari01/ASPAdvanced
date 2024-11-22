using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using Shop.Application.Contract.Dtos.Commons;
using Shop.Application.Contract.IServices.Products;
using Shop.Application.Contract.IServices.Users;
using Shop.Application.Contract.MappingConfiguration;
using Shop.Application.Services.Products;
using Shop.Application.Services.Users;
using Shop.Application.UnitOfWorks;
using Shop.EndPoint.API;
using Shop.EndPoint.API.Middlewares;
using Shop.EndPoint.API.Securities;
using Shop.InfraStructure.Contexts;
using Shop.InfraStructure.Interceptors;
using Shop.InfraStructure.IRepositories;
using Shop.InfraStructure.Repositories;
using Shop.InfraStructure.UnitOfWorks;
using Shop.Model.Models.IdentityModels;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var levelSwitch = new LoggingLevelSwitch();


builder.AddSerilogProvider("")
       .AddSwagger();

builder.Services.AddMemoryCache();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(x =>
{
    x.RegisterType<UnitOfWorkInterceptor>();
    x.RegisterType<ProductAdminService>().As<IProductAdminService>()
    .EnableInterfaceInterceptors()
    .InterceptedBy(typeof(UnitOfWorkInterceptor));
}));

//builder.Logging.AddConsole();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:800")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});


builder.Services.AddControllers();

builder.Services.AddHttpClient();

RegisterServices(builder);

builder.Services.AddDbContext<ShopContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("GeniusesShopDB"));
    x.AddInterceptors(new ProductHistoryInterceptor());
    x.EnableDetailedErrors();
    x.EnableSensitiveDataLogging();
});



builder.Services.Configure<ImagePathProvider>(x => x.ImagePath = builder.Configuration.GetValue<string>("ImagePath"));

ImagePathProvider.HttpImagePath = builder.Configuration.GetValue<string>("HttpImagePath");

builder.Services
    .AddIdentityCore<ApplicationUser>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ShopContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(cfg =>
   {
       cfg.TokenValidationParameters = new TokenValidationParameters()
       {
           ValidateIssuer = false,
           ValidateAudience = false,
           ValidateIssuerSigningKey = true,
           RequireExpirationTime = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vjhgjhgbk32ییسشjkjloij6576hiuhiujhgh87y"))
       };
   });


builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("UserPolicy",
    //policyBuilder => policyBuilder.RequireRole("User"));
    options.AddPolicy("UserPolicy",
    policyBuilder => policyBuilder.RequireRole("User"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseMiddleware(typeof(CustomExceptionHandlerMiddleware));

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

static IServiceScope SeedRole(WebApplication app)
{
    var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if (roleManager.FindByNameAsync("USER").GetAwaiter().GetResult() == null)
    {
        roleManager.CreateAsync(new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "User",
            NormalizedName = "USER"
        }).GetAwaiter().GetResult();
    }

    return scope;
}

static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IProductUserService, ProductUserService>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();

    builder.Services.AddScoped<IInventoryExternalService, InventoryExternalService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddSingleton<ITokenHandler, Shop.EndPoint.API.Securities.TokenHandler>();
    builder.Services.AddScoped<IUserContext, UserContext>();
    // builder.Services.AddScoped<IProductAdminService, ProductAdminService>();
    builder.Services.AddScoped(typeof(IRepository<,>), typeof(BaseRepoitory<,>));
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddSingleton<UnitOfWorkAttributeManager>();
}

