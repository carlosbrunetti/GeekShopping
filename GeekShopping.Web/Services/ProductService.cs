using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentException(nameof(HttpClient));
        }

        public async Task<IEnumerable<ProductViewModel>> FindAll(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> Create(ProductViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
                throw new Exception("Something went wrong with the Api");
        }

        public async Task<ProductViewModel> Update(ProductViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
                throw new Exception("Something went wrong with the Api");
        }

        public async Task<bool> Delete(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrong with the Api");
        }
    }
}
