using DomainLayer.Models;
using DomainLayer.Contracts;
using Service.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Service.Specifications
{
     class ProductWithBrandAndTypeSpecification  : BaseSpecifications<Product , int>
     {
        public ProductWithBrandAndTypeSpecification(ProductQueryParams queryParams)
            : base(p => (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId)
            && (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId)
            && (string.IsNullOrWhiteSpace(queryParams.searchValue)|| p.Name.ToLower().Contains(queryParams.searchValue.ToLower())))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            switch (queryParams.sortingOption)
            {
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                default:
                    break;
            }
        }
        public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

     }
    
    
}
