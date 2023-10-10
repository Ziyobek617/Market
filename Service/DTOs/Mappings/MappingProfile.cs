using AutoMapper;
using Market.Domain.Entites;
using Market.Service.DTOs.CustomerDto;
using Market.Service.DTOs.OrderDtos;
using Market.Service.DTOs.ProductDtos;

namespace Market.Service.DTOs.Mappings;

public class MappingProfile : Profile
{
    public static IMapper Initalize()
    {
        var config = new MapperConfiguration(
        cfg =>
        {
            #region Customer
            cfg.CreateMap<Customer,CustomerForCreationDto>().ReverseMap();
            cfg.CreateMap<Customer,CustomerForUpdateDto>().ReverseMap();
            cfg.CreateMap<Customer,CustomerForResultDto>().ReverseMap();
            #endregion

            #region Order
            cfg.CreateMap<Order, OrderForCreationDto>().ReverseMap();
            cfg.CreateMap<Order, OrderForResultDto>().ReverseMap();
            #endregion

            #region Product
            cfg.CreateMap<Product, ProductForCreationDto>().ReverseMap();
            cfg.CreateMap<Product, ProductForUpdateDto>().ReverseMap();
            cfg.CreateMap<Product, ProductForResultDto>().ReverseMap();
            #endregion

        }
            );
        return config.CreateMapper();
    }
}
