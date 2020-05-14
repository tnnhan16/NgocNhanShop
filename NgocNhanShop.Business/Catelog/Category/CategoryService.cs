﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NgocNhanShop.Business.Catelog.Category.Dtos;
using NgocNhanShop.Business.Catelog.Dtos;
using NgocNhanShop.Data.Entities;
using NgocNhanShop.EF.Data;
using NgocNhanShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgocNhanShop.Business.Catelog.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly NgocNhanShopDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(NgocNhanShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> CreateCategoryAsync(CategoryCreateRequest request)
        {
            var category = _mapper.Map<Categories>(request);
            if(category == null)
            {
                throw new NgocNhanShopException($"Cannot create category");
            }
            _context.Categories.Add(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(int CategoryId)
        {
            var category = await _context.Categories.FirstAsync(x => x.Id == CategoryId);
            if (category == null)
            {
                throw new NgocNhanShopException($"Cannot find category id {CategoryId}");
            }
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<CategoryViewModel>> GetAllPaging(CategoryPageRequest request)
        {
            var query = _context.Categories;
            if (!string.IsNullOrEmpty(request.KeyWork))
            {
                query.Where(x => x.Name.Contains(request.KeyWork));
            }
            var listCategory = await query.ToListAsync();

            var categorys = _mapper.Map<List<CategoryViewModel>>(listCategory);

            var total = await query.CountAsync();

            var result = categorys.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();

            var pageResult = new PageResult<CategoryViewModel>()
            {
                Items = result,
                Total = total,
            };

            return pageResult;
        }

        public async Task<CategoryViewModel> GetByProductId(int CategoryId)
        {
            var category = await _context.Categories.FindAsync(CategoryId);
            if(category == null)
            {
                throw new NgocNhanShopException($"Cannot find category id {CategoryId}");
            }
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<int> UpdateCategory(int CategoryId, CategoryUpdateRequest request)
        {
            var category = await _context.Categories.FindAsync(CategoryId);
            if (category == null)
            {
                throw new NgocNhanShopException($"Cannot find category id {CategoryId}");
            }
            category = _mapper.Map<Categories>(request);
            return await _context.SaveChangesAsync();
        }
    }
}
