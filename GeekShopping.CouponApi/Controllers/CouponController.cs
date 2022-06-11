using GeekShopping.CouponApi.Data.ValueObjects;
using GeekShopping.CouponApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CouponApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [Authorize]
        [HttpGet("{couponCode}")]
        public async Task<ActionResult<CouponVO>> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _repository.GetCouponByCouponCode(couponCode);

            if (coupon == null)
                return NotFound();

            return Ok(coupon);
        }
    }
}
