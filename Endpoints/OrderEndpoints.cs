using AutoMapper;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                CustomerId = 101,
                OrderNumber = "ORD-1001",
                OrderDate = DateTime.UtcNow.AddDays(-5),
                ShippedDate = DateTime.UtcNow.AddDays(-2),
                TotalAmount = 249.99m,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new Order
            {
                Id = 2,
                CustomerId = 102,
                OrderNumber = "ORD-1002",
                OrderDate = DateTime.UtcNow.AddDays(-3),
                ShippedDate = null,
                TotalAmount = 129.50m,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new Order
            {
                Id = 3,
                CustomerId = 103,
                OrderNumber = "ORD-1003",
                OrderDate = DateTime.UtcNow.AddDays(-1),
                ShippedDate = null,
                TotalAmount = 399.00m,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            }
        };

        var orderGroup = app.MapGroup("/api/orders").WithTags("Order Endpoints");

        orderGroup.MapGet("/", (IMapper mapper) => Results.Ok(mapper.Map<List<OrderDto>>(orders)));

        orderGroup.MapGet("/{id:int}", (IMapper mapper, int id) =>
        {
            var order = orders.Find(u => u.Id == id);
            return order is null ? Results.NotFound($"Vehicle with ID {id} was not found.") : Results.Ok(mapper.Map<OrderDto>(order));
        });

        orderGroup.MapPost("/", (IMapper mapper, Order order) =>
        {
            var dto = mapper.Map<OrderDto>(order);

            var response = new ApiResponse<OrderDto>
            {
                Data = dto,
                Message = "Order created successfully"
            };

            return Results.Created($"/api/orders/{dto.Id}", response);
        })
        .Produces<Vehicle>(StatusCodes.Status201Created);
    }
}