using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Newtonsoft.Json;
namespace Mango.Web.Service
{
    public class CouponService(IBaseService service) : ICouponService
    {
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponAPIBase + "/api/coupon/",
                Data = couponDto// JsonConvert.SerializeObject(couponDto)
            });
        }
        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                // https://localhost:7001/api/coupon
                Url = SD.CouponAPIBase + "/api/coupon/" + id
            });
        }
        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }
        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }
        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/" + id
            });
        }
        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponAPIBase + "/api/coupon/",
                Data = JsonConvert.SerializeObject(couponDto)
            });
        }
    }
}
