using NgocNhanShop.Business.Common.Dtos;
using NgocNhanShop.Business.Catelog.Prodcuts.Dtos;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.Catelog.Prodcuts
{
    public interface IProductService
    {
        Task<Product> CreateProduct(ProductCreateRequest request);
        Task<int> UpdateProduct(int ProductId, ProductUpdateRequest request);
        Task<int> DeleteProduct(int ProductId);
        Task<ProductViewModel> GetByProductId(int ProductId);

        Task<List<ProductViewModel>> GetAll();
        Task<PageResult<ProductViewModel>> GetAllPaging(ProductPageRequest request);
    }
}
