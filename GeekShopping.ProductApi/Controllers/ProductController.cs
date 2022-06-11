using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentException(nameof(productRepository));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> Get(long id)
        {
            var product = await _productRepository.FindById(id);

            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Get()
        {
            var product = await _productRepository.FindAll();
            return Ok(product);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductVO>> Post([FromBody] ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            var product = await _productRepository.Create(productVO);

            return Ok(product);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Put([FromBody] ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            var product = await _productRepository.Update(productVO);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var result = await _productRepository.Delete(id);

            if(result == false)
                return BadRequest();
            return Ok(result);
        }

    }
}
