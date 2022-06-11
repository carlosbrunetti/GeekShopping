using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            return _mapper.Map<ProductVO>(await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<ProductVO> Create(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);
            _context.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
                
                if (product == null)
                        return false;
                
                _context.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
