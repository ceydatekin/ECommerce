using ECommerce.BasketService.Core.Interfaces;
using ECommerce.BasketService.Infrastructure.Data;
using StackExchange.Redis;

namespace ECommerce.BasketService.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Redis Configuration
        builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
                                                                  ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));

        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
        builder.Services.AddScoped<IBasketService, Services.BasketService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}