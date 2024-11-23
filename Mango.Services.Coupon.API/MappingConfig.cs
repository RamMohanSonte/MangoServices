using AutoMapper;
using Mango.Services.Coupon.API.Models.Dto;
namespace Mango.Services.Coupon.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Mango.Services.Coupon.API.Models.Coupon, CouponDto>();
                config.CreateMap<CouponDto, Mango.Services.Coupon.API.Models.Coupon>();
            });
        }
    }
}
