using FluentValidation;
using NgocNhanShop.Business.Catelog.Prodcuts.Dtos;
using NgocNhanShop.Validator.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Validator.Validator.Product
{
    public class ProductCreateRequestValidator : AbstractValidator<ProductCreateRequest>
    {
        public ProductCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(String.Format(MessageValidator_VN.isRequire, "Tên sản phẩm"));
        }
    }
}
