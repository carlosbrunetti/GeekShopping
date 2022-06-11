using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            return View(await _productService.FindAll(string.Empty));
        }

        public IActionResult ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.Create(model,token);
                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var product = await _productService.FindById(id,token);
            if (product != null)
                return View(product);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.Update(model,token);
                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var product = await _productService.FindById(id,token);
            if (product != null)
                return View(product);
            return NotFound();
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ProductDelete(ProductViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.Delete(model.Id,token);
            if (response)
                return RedirectToAction(nameof(ProductIndex));

            return View(model);
        }

    }
}
