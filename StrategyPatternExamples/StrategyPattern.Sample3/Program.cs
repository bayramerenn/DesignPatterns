using StrategyPattern.Sample3.Strategy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GrillingService>();
builder.Services.AddTransient<RoastingService>();
builder.Services.AddTransient<DeepFryingService>();

builder.Services.AddScoped<ServiceResolver>(serviceProvider => key =>
{
    switch (key)
    {
        case CookingType.Grill:
            return serviceProvider.GetRequiredService<GrillingService>();
        case CookingType.Roast:
            return serviceProvider.GetRequiredService<RoastingService>();
        case CookingType.Fry:
            return serviceProvider.GetRequiredService<DeepFryingService>();
        default:
            throw new KeyNotFoundException();
    }
});

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

app.Run();
