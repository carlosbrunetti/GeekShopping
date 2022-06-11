using AutoMapper;
using GeekShopping.CouponApi.Data.ValueObjects;
using GeekShopping.CouponApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponApi.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly SqlContext _sqlContext;
        private IMapper _mapper;

        public CouponRepository(SqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode) =>
            _mapper.Map<CouponVO>(await _sqlContext.Coupons.SingleOrDefaultAsync(c => c.CouponCode == couponCode));

    }
}
