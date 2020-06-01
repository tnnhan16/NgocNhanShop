using NgocNhanShop.ViewModel.Catelog.Category.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.Catelog.Prodcuts.Dtos
{
    public class ProductUpdateRequest
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UserUpdate { get; set; }
        public int CategoryId { get; set; }

        public List<CategoryViewModel> categoryViews { get; set; }
    }
}
