using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.ProductService.Core.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("Description")]
    public string Description { get; set; }

    [BsonElement("Price")]
    public decimal Price { get; set; }

    [BsonElement("StockQuantity")]
    public int StockQuantity { get; set; }

    [BsonElement("Category")]
    public string Category { get; set; }

    [BsonElement("ImageUrl")]
    public string ImageUrl { get; set; }

    [BsonElement("CreatedAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("UpdatedAt")]
    public DateTime UpdatedAt { get; set; }
}
