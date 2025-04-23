using DomainLayer.Models;
using DomainLayer.Contracts;
using Service.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
     class ProductWithBrandAndTypeSpecification  : BaseSpecifications<Product , int>
     {
        public ProductWithBrandAndTypeSpecification(int? BrandId, int? TypeId)
            : base(p => (!BrandId.HasValue || p.BrandId == BrandId)
            && (!TypeId.HasValue || p.TypeId == TypeId))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
        public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
    
    
}
