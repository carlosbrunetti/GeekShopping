using GeekShopping.CartApi.Data.ValueObjects;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.CartApi.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Coupon";

        public CouponRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<CouponVO> GetCoupon(string couponCode, string[] token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token[0], token[1]);
            var response = await _client.GetAsync($"{BasePath}/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK) 
                return new CouponVO();
            
            return JsonSerializer.Deserialize<CouponVO>(content,
                new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true });
        }
    }
}