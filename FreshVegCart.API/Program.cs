using FreshVegCart.API.Data;
using FreshVegCart.API.Data.Entities;
using FreshVegCart.API.Endpoints;
using FreshVegCart.API.Services;
using FreshVegCart.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IAuthService, AuthService>()
    .AddTransient<IOrderService, OrderService>()
    .AddTransient<IProductService, ProductService>()
    .AddTransient<IUserService, UserService>()
    .AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer"),
            ValidateIssuer = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:SecretKey"))),
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    AutoMigrateDb(app.Services);
}

app.UseHttpsRedirection();

app.UseAuthentication().UseAuthorization();

app.MapAuthEndpoints()
    .MapOrderEndpoints()
    .MapProductEndpoints()
    .MapUserEndpoints();

app.Run();

static void AutoMigrateDb(IServiceProvider sp)
{
    var scope = sp.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetAppliedMigrations().Any())
    {
        context.Database.Migrate();
    }
    else
    {
        context.Database.EnsureCreated();
    }
}