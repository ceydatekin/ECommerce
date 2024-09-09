namespace ECommerce.BasketService.Core.Entities;

public class Basket
{
    public string UserId { get; set; }

    public string UserName { get; set; }

    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
}