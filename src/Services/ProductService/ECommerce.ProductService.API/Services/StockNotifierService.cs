using ECommerce.ProductService.Core.Entities;
using ECommerce.Service;
using MassTransit;

namespace ECommerce.ProductService.API.Services;

public class StockNotifierService(IPublishEndpoint publishEndpoint)
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    private async Task CheckStockAndPublishEventAsync(Product product)
    {
        if (product.StockQuantity <= 0)
        {
            var @event = new ProductOutOfStockEvent { ProductId = product.Id, };

            await _publishEndpoint.Publish(@event);
        }
    }
}