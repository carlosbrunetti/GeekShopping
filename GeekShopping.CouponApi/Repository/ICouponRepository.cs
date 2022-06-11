using GeekShopping.CouponApi.Data.ValueObjects;

namespace GeekShopping.CouponApi.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}
