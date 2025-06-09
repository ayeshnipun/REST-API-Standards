public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Age = 25,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new User
            {
                Id = 2,
                FirstName = "Jade",
                LastName = "Wilson",
                Age = 26,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new User
            {
                Id = 3,
                FirstName = "Bob",
                LastName = "Paine",
                Age = 27,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
        };

        app.MapGet("/api/users", () =>
        {
            return Results.Ok(users);
        });

        app.MapGet("/api/users/{id:int}", (int id) =>
        {
            var user = users.Find(u => u.Id == id);

            if (user == null)
                return Results.NotFound($"User with ID {id} was not found.");

            return Results.Ok(user);
        });

        app.MapPost("/api/users", (User user) =>
        {
            return Results.Created($"/users/{user?.Id}", user);
        })
        .Produces<User>(StatusCodes.Status201Created);
    }
}