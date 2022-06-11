using AutoMapper;
using GeekShopping.CartApi.Data.ValueObjects;
using GeekShopping.CartApi.Model;

namespace GeekShopping.CartApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartVO, Cart>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
