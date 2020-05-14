using AutoMapper;
using NgocNhanShop.Business.Catelog.Category.Dtos;
using NgocNhanShop.Business.Catelog.Prodcuts.Dtos;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapping product
            CreateMap<Product, ProductCreateRequest>();
            CreateMap<Product, ProductUpdateRequest>();
            CreateMap<Product, ProductViewModel>();

            //mapping category
            CreateMap<Categories, CategoryCreateRequest>();
            CreateMap<Categories, CategoryUpdateRequest>();
            CreateMap<Categories, CategoryViewModel>();
        }
    }
}
