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
        
        var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");

        builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoConnectionString));

        builder.Services.AddScoped<IMongoDatabase>(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase("Product");
        });
        builder.Services.AddControllers();
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // API endpoint'lerini tanımlayın
        app.MapControllers(); 

        app.Run();
    }
}