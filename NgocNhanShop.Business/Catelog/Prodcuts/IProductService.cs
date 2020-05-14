using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Business.Catelog.Prodcuts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.Catelog.Prodcuts
{
    public interface IProductService
    {
        Task<int> CreateProduct(ProductCreateRequest request);
        Task<int> UpdateProduct(int ProductId, ProductUpdateRequest request);
        Task<int> DeleteProduct(int ProductId);
        Task<ProductViewModel> GetByProductId(int ProductId);
        Task<PageResult<ProductViewModel>> GetAllPaging(CategoryPageRequest request);
    }
}
