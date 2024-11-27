//https://www.youtube.com/watch?v=gGa7SLk1-0Q&t=1556s

using Mango.Web.Models;
using Mango.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Mango.Web.Controllers
{
    public class CouponController(ICouponService _couponService) : Controller
    {
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> list = [];
            var responseDto = await _couponService.GetAllCouponsAsync();
            if (responseDto != null)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CouponCreate(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _couponService.CreateCouponAsync(couponDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View(couponDto);
        }
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? responseDto = await _couponService.GetCouponByIdAsync(couponId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                CouponDto? model=JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Result));
                return View(model);
               // return RedirectToAction(nameof(CouponIndex));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? responseDto = await _couponService.DeleteCouponAsync(couponDto.CouponId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }
            return View(couponDto);
        }
    }
}
