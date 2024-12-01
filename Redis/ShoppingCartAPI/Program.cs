// ShoppingCartAPI/Program.cs
using ShoppingCart.API.Mappings;
using ShoppingCart.Business;
using ShoppingCart.Data;
using ShoppingCart.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using ShoppingCart.Infrastructure.Utilities;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Data.Services;
using ShoppingCart.Business.Services;
using ShoppingCart.Business.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register Infrastructure
builder.Services.AddSingleton<IRedisService, RedisService>();

// Register Data Access
builder.Services.AddScoped<ICartRepository, CartRepository>();

// Register Business Logic
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
