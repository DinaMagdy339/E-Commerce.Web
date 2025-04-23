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
        public ProductWithBrandAndTypeSpecification(int? BrandId, int? TypeId, ProductSortingOptions sortingOption)
            : base(p => (!BrandId.HasValue || p.BrandId == BrandId)
            && (!TypeId.HasValue || p.TypeId == TypeId))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            switch (sortingOption)
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
