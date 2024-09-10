using ECommerce.BasketService.Core.Interfaces;
using ECommerce.Service;
using MassTransit;

namespace ECommerce.BasketService.API.Event;

public class ProductOutOfStockConsumer(IBasketService basketRepository) : IConsumer<ProductOutOfStockEvent>
{
    public async Task Consume(ConsumeContext<ProductOutOfStockEvent> context)
    {
        var productId = context.Message.ProductId;

        await basketRepository.RemoveProductFromAllCartsAsync(productId);
    }
}