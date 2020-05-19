using AutoMapper;
using NgocNhanShop.Business.Catelog.Category.Dtos;
using NgocNhanShop.Business.Catelog.Prodcuts.Dtos;
using NgocNhanShop.Business.System.Dtos;
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
            //mapping product create
            CreateMap<ProductCreateRequest, Product>()
                .ForMember(n => n.CreateTime, t => t.MapFrom(o => DateTime.Now))
                .ForMember(n => n.UpdateTime, t => t.MapFrom(o => DateTime.Now))
                .ForMember(n => n.IsDelete, t => t.MapFrom(o => false));

            //mapping product update
            CreateMap<ProductUpdateRequest, Product>()
                .ForMember(n => n.UpdateTime, t => t.MapFrom(o => DateTime.Now)).ReverseMap();

            CreateMap<Product, ProductViewModel>().ReverseMap();

            //mapping category create
            CreateMap<CategoryCreateRequest, Categories>()
                .ForMember(n => n.CreateTime, t => t.MapFrom(o => DateTime.Now))
                .ForMember(n => n.UpdateTime, t => t.MapFrom(o => DateTime.Now))
                .ForMember(n => n.IsDelete, t => t.MapFrom(o => false));

            //mapping category update
            CreateMap<CategoryUpdateRequest, Categories>()
                .ForMember(n => n.UpdateTime, t => t.MapFrom(o => DateTime.Now)).ReverseMap();

            CreateMap<Categories, CategoryViewModel>().ReverseMap();

            CreateMap<AppUser,UserRegisterRequest>().ReverseMap();
        }
    }
}
