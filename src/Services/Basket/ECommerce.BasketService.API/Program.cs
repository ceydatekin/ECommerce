using ECommerce.BasketService.API.Event;
using ECommerce.BasketService.API.Helper;
using ECommerce.BasketService.API.Services;
using ECommerce.BasketService.Core.Interfaces;
using ECommerce.BasketService.Infrastructure.Data;
using MassTransit;
using StackExchange.Redis;

namespace ECommerce.BasketService.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var redisConfiguration = configuration.GetSection("Redis:Configuration").Value;
            return ConnectionMultiplexer.Connect(redisConfiguration);
        });
        
        builder.Services.AddHttpClient("ProductApiClient", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5248/");
        });
        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
        builder.Services.AddScoped<IBasketService, Services.BasketService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var rabbitMQSettings = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<ProductOutOfStockConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMQSettings.Host, "/", h =>
                {
                    h.Username(rabbitMQSettings.Username);
                    h.Password(rabbitMQSettings.Password);
                });
                cfg.ReceiveEndpoint("product-out-of-stock-queue",
                    e => { e.ConfigureConsumer<ProductOutOfStockConsumer>(context); });
            });
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        builder.Services.AddTransient<ProductOutOfStockConsumer>();
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowAll");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}