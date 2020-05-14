using NgocNhanShop.Business.Catelog.Category.Dtos;
using NgocNhanShop.Business.Catelog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.Catelog.Category
{
    public interface ICategoryService
    {
        Task<int> CreateCategoryAsync(CategoryCreateRequest request);
        Task<int> UpdateCategory(int CategoryId, CategoryUpdateRequest request);
        Task<int> DeleteCategory(int ProductId);
        Task<CategoryViewModel> GetByProductId(int ProductId);
        Task<PageResult<CategoryViewModel>> GetAllPaging(CategoryPageRequest request);
    }
}
