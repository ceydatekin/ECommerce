﻿namespace ECommerce.BasketService.Core.DTOs;

public sealed record ProductAvailabilityDto
{
    public bool IsAvailable { get; init; }
    public decimal Price { get; init; }
}