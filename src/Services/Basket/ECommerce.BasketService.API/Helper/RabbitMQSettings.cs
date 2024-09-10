namespace ECommerce.BasketService.API.Helper;

public sealed record RabbitMQSettings
{
    public string Host { get; init; }

    public string Username { get; init; }

    public string Password { get; init; }
}