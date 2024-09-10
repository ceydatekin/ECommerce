using ECommerce.ProductService.API.Helper;
using ECommerce.ProductService.Core.Interfaces;
using ECommerce.ProductService.Infrastructure.Data;
using MassTransit;
using MongoDB.Driver;

namespace ECommerce.ProductService.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, Services.ProductService>();

        var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");

        builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoConnectionString));

        builder.Services.AddScoped<IMongoDatabase>(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase("Product");
        });
        builder.Services.AddControllers();


        var rabbitMQSettings = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

        builder.Services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMQSettings.Host, "/", h =>
                {
                    h.Username(rabbitMQSettings.Username);
                    h.Password(rabbitMQSettings.Password);
                });
            });
        });

        builder.Services.AddTransient<Services.ProductService>();


        builder.Services.AddControllers();
        var app = builder.Build();

        app.UseCors(builder =>
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader());

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();
    }
}