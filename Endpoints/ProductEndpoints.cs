public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Calculator",
                Description = "Used to make calculations",
                Price = 100,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new Product
            {
                Id = 2, Name = "Phone",
                Description = "Used to make calls",
                Price = 200,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new Product
            {
                Id = 3,
                Name = "Watch",
                Description = "Used to tell the time ",
                Price = 50,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
        };

        var productGroup = app.MapGroup("/api/products").WithTags("Product Endpoints");

        productGroup.MapGet("/", () => Results.Ok(products));

        productGroup.MapGet("/{id:int}", (int id) =>
        {
            var product = products.Find(u => u.Id == id);
            return product is null ? Results.NotFound($"Product with ID {id} was not found.") : Results.Ok(product);
        });

        productGroup.MapPost("/", (Product product) =>
        {
            return Results.Created($"/products/{product?.Id}", product);
        })
        .Produces<Product>(StatusCodes.Status201Created);
    }
}