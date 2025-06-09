using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<Company, CompanyDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<Order, OrderDto>();
        CreateMap<Vehicle, VehicleDto>();
    }
}