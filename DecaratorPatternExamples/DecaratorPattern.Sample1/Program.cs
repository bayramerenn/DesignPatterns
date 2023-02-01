using Bogus;
using DecaratorPattern.Sample1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.Decorate<IProductRepository, CachedProductRepositoryDecorator>();

var redisConfig = builder.Configuration.GetSection("Redis").Get<RedisConfiguration>();

builder.Services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
if (!context.Products.Any())
{
    context.Products.AddRange(GetProducts());
    context.SaveChanges();
}

var supportedCultures = new[] { "en-US", "fr" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


app.UseRequestLocalization(localizationOptions);

app.Run();

List<Product> GetProducts()
{
    return new Faker<Product>()
        .RuleFor(x => x.Name, f => f.Vehicle.Fuel())
        .RuleFor(x => x.Quantity, f => f.Random.Int())
        .RuleFor(x => x.Price, f => f.Random.Decimal())
        .Generate(10);
}