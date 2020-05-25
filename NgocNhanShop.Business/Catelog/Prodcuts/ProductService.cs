using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NgocNhanShop.ViewModel.Common.Dtos;
using NgocNhanShop.ViewModel.Catelog.Prodcuts.Dtos;
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
        public async Task<Product> CreateProduct(ProductCreateRequest request)
        {
            var product = _mapper.Map<Product>(request);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<int> DeleteProduct(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                throw new NgocNhanShopException($"Cannot find product id {ProductId}");
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(ProductPageRequest request)
        {

            var query = (from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.Id
                        select new { p,c });
            if (!String.IsNullOrEmpty(request.KeyWork))
            {
                query = query.Where(x => x.p.Name.Contains(request.KeyWork) || x.c.Name.Contains(request.KeyWork));
                   
            }
            if (request.CategoryId > 0)
            {
                query = query.Where(x => x.c.Id == request.CategoryId);
            }
            var products = await query.Select(x=> new ProductViewModel 
            { 
                Id = x.p.Id,
                Name = x.p.Name,
                CategoryName = x.c.Name,
                Price = x.p.Price,
                UserCreate = x.p.UserCreate,
                CreateTime = x.p.CreateTime
            }).ToListAsync();

            //var products = _mapper.Map<List<ProductViewModel>>(listProduct);

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
            if (product == null)
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

            _mapper.Map<ProductUpdateRequest,Product >(request,product);

            return await _context.SaveChangesAsync();
        }
    }
}
