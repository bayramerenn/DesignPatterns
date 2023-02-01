using StrategyPattern.Sample1.Operators;
using StrategyPattern.Sample1.Strategy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMathStrategy, MathStrategy>();
builder.Services.AddScoped<IMathOperator, AddOperator>();
builder.Services.AddScoped<IMathOperator, SubstractOperator>();
builder.Services.AddScoped<IMathOperator, MultipleOperator>();
builder.Services.AddScoped<IMathOperator, DivideOperator>();

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
