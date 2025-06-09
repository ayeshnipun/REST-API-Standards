public static class CompanyEndpoints
{
    public static void MapCompanyEndpoints(this IEndpointRouteBuilder app)
    {
        var companies = new List<Company>
        {
            new Company
            {
                Id = 1,
                Name = "Ascentic",
                Location = "Rajagiriya",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new Company
            {
                Id = 2,
                Name = "WSO2",
                Location = "Colombo",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new Company
            {
                Id = 3,
                Name = "Gapstars",
                Location = "Rajagiriya",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
        };

        app.MapGet("/api/companies", () =>
        {
            return Results.Ok(companies);
        });

        app.MapGet("/api/companies/{id:int}", (int id) =>
        {
            var company = companies.Find(u => u.Id == id);

            if (company == null)
                return Results.NotFound($"Company with ID {id} was not found.");

            return Results.Ok(company);
        });

        app.MapPost("/api/companies", (Company company) =>
        {
            return Results.Created($"/companies/{company?.Id}", company);
        })
        .Produces<Company>(StatusCodes.Status201Created);
    }
}