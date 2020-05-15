using NgocNhanShop.Business.Catelog.Category.Dtos;
using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.Catelog.Category
{
    public interface ICategoryService
    {
        Task<Categories> CreateCategory(CategoryCreateRequest request);
        Task<int> UpdateCategory(int CategoryId, CategoryUpdateRequest request);
        Task<int> DeleteCategory(int CategoryId);
        Task<CategoryViewModel> GetByCategoryId(int CategoryId);
        Task<PageResult<CategoryViewModel>> GetAllPaging(CategoryPageRequest request);
    }
}
