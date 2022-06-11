using AutoMapper;
using GeekShopping.CouponApi.Data.ValueObjects;
using GeekShopping.CouponApi.Model.Base;

namespace GeekShopping.CouponApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
