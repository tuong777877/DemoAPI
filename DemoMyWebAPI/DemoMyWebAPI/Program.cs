global using DemoMyWebAPI.Data;
global using DemoMyWebAPI.Repository.Constracts;
global using DemoMyWebAPI.Repository.Implements;

//using DemoMyWebAPI.Services;
global using Microsoft.EntityFrameworkCore;
using DemoMyWebAPI.Models;
using DemoMyWebAPI.Repositories.Constracts;
using DemoMyWebAPI.Repositories.Implements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
using System.Text;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<CarStoreContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));
    builder.Services.AddScoped<ICateCarRepository, CateCarRepository>();
    builder.Services.AddScoped<ICarRepository, CarRepository>();
    builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
    builder.Services.AddScoped<ICateCustomerRepository, CateCustomerRepository>();

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    var secretkey = builder.Configuration["AppSettings:SecretKey"];
    var secretkeyBytes = Encoding.UTF8.GetBytes(secretkey);
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // tu cap token
            ValidateIssuer = false,
            ValidateAudience = false,

            //ky vao token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretkeyBytes),

            ClockSkew = TimeSpan.Zero
        };
    });
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}