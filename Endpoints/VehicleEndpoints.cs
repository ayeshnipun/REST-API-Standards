using AutoMapper;

public static class VehicleEndpoints
{
    public static void MapVehicleEndpoints(this IEndpointRouteBuilder app)
    {
        var vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Yaris",
                Price = 10000000,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new Vehicle
            {
                Id = 2,
                Brand = "Suzuki",
                Model = "Wagon R",
                Price = 6500000,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
            new Vehicle
            {
                Id = 3,
                Brand = "Honda",
                Model = "Jaaz",
                Price = 9500000,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                LastUpdatedAt = DateTime.UtcNow,
                LastUpdatedBy = "Admin",
                IsDeleted = false
            },
        };

        var vehicleGroup = app.MapGroup("/api/vehicles").WithTags("Vehicle Endpoints");

        vehicleGroup.MapGet("/", (IMapper mapper) =>
        {
            // Map the list of vehicles to a list of VehicleDto objects
            var vehicleDtos = mapper.Map<List<VehicleDto>>(vehicles);

            // Create an API response with the mapped data
            var response = new ApiResponse<List<VehicleDto>>
            {
                Data = vehicleDtos
            };

            // Return the response with HTTP 200 OK
            return Results.Ok(response);
        });

        vehicleGroup.MapGet("/{id:int}", (IMapper mapper, int id) =>
        {
            var vehicle = vehicles.Find(u => u.Id == id);

            return vehicle is null
                ? Results.NotFound(new ApiResponse<VehicleDto> { Message = $"Vehicle with ID {id} was not found.", Success = false, Data = null })
                : Results.Ok(new ApiResponse<VehicleDto> { Data = mapper.Map<VehicleDto>(vehicle) });
        });

        vehicleGroup.MapPost("/", (IMapper mapper, Vehicle vehicle) =>
        {
            var dto = mapper.Map<VehicleDto>(vehicle);

            var response = new ApiResponse<VehicleDto>
            {
                Data = dto,
                Message = "Vehicle created successfully"
            };

            return Results.Created($"/api/vehicles/{dto.Id}", response);
        })
        .Produces<Vehicle>(StatusCodes.Status201Created);
    }
}