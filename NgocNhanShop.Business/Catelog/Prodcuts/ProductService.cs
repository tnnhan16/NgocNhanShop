using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Business.Catelog.Prodcuts.Dtos;
using NgocNhanShop.Data.Entities;
using NgocNhanShop.EF.Data;
using NgocNhanShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.Catelog.Prodcuts
{
    public class ProductService : IProductService
    {
        private readonly NgocNhanShopDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(NgocNhanShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> CreateProduct(ProductCreateRequest request)
        {
            var product = _mapper.Map<Product>(request);
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(int ProductId)
        {
            var product = await _context.Products.FirstAsync(x => x.Id == ProductId);
            if(product == null)
            {
                throw new NgocNhanShopException($"Cannot find product id {ProductId}");
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(CategoryPageRequest request)
        {

            var query = from p in _context.Products
                        join c in _context.Categories on p.Id equals c.Id
                        select new { p, c };
            if (!string.IsNullOrEmpty(request.KeyWork))
            {
                query = query.Where(x => x.p.Name.Contains(request.KeyWork))
                    .Where(x=>x.c.Name.Contains(request.KeyWork));
            }
            if(request.CategoryId > 0)
            {
                query = query.Where(x => x.c.Id == request.CategoryId);
            }
            var listProduct = await query.ToListAsync();

            var products = _mapper.Map<List<ProductViewModel>>(listProduct);

            var total = await query.CountAsync();

            var result = products.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();

            var pageResult = new PageResult<ProductViewModel>()
            {
                Items = result,
                Total = total,
            };

            return pageResult;
        }

        public async Task<ProductViewModel> GetByProductId(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if(product == null)
            {
                throw new NgocNhanShopException($"Cannot find product id {ProductId}");
            }
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<int> UpdateProduct(int ProductId, ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                throw new NgocNhanShopException($"Cannot find product id {ProductId}");
            }
            product = _mapper.Map<Product>(request);
            return await _context.SaveChangesAsync();
        }
    }
}
