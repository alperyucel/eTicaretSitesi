using AlisverisLab.Entity.POCO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.DTO
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public List<string>? Paths { get; set; }
        public int Stock { get; set; }

        public int? GId { get; set; }
        public string? GProductName { get; set; }
        public string? GProductDescription { get; set; }
        public double? GPrice { get; set; }
        public List<string>? GPaths { get; set; }
        public int? GStock { get; set; }

        public int[]? SelectedCategoryIds { get; set; }
        public int[]? GSelectedCategoryIds { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<Category>? CategoriesModel { get; set; }
    }
}
