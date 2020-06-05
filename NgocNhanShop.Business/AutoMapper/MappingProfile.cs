using AutoMapper;
using NgocNhanShop.ViewModel.Catelog.Category.Dtos;
using NgocNhanShop.ViewModel.Catelog.Prodcuts.Dtos;
using NgocNhanShop.ViewModel.System.Users.Dtos;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using NgocNhanShop.ViewModel.System.Roles.Dtos;

namespace NgocNhanShop.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapping product
            CreateMap<Product, ProductCreateRequest>().ReverseMap()
               .ForMember(n => n.CreateTime, t => t.MapFrom(o => DateTime.Now))
               .ForMember(n => n.IsDelete, t => t.MapFrom(o => false));

            CreateMap<ProductUpdateRequest, Product>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();

            //mapping category
            CreateMap<CategoryCreateRequest, Categories>()
                .ForMember(n => n.CreateTime, t => t.MapFrom(o => DateTime.Now))
                .ForMember(n => n.UpdateTime, t => t.MapFrom(o => DateTime.Now))
                .ForMember(n => n.IsDelete, t => t.MapFrom(o => false));
            CreateMap<CategoryUpdateRequest, Categories>()
                .ForMember(n => n.UpdateTime, t => t.MapFrom(o => DateTime.Now)).ReverseMap();
            CreateMap<Categories, CategoryViewModel>().ReverseMap();

            //mapping user
            CreateMap<AppUser, UserRegisterRequest>().ReverseMap()
               .ForMember(n => n.CreateTime, t => t.MapFrom(o => DateTime.Now));
            CreateMap<UserUpdateRequest, AppUser>()
                .ForMember(n => n.UpdateTime, t => t.MapFrom(o => DateTime.Now));
            CreateMap<AppUser, UserViewModel>().ReverseMap();

            //mapping role
            CreateMap<AppRole, RoleRegisterRequest>().ReverseMap()
               .ForMember(n => n.CreateTime, t => t.MapFrom(o => DateTime.Now));
            CreateMap<RoleUpdateRequest, AppRole>()
                .ForMember(n => n.UpdateTime, t => t.MapFrom(o => DateTime.Now));
            CreateMap<AppRole, RoleViewModel>().ReverseMap();

        }
    }
}
