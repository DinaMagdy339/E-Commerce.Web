using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTo>> GetAllProductsAsync();
        Task<ProductDTo> GetProductByIdAsync(int id);
        Task<IEnumerable<TypeDTo>> GetAllTypessAsync();
        Task<IEnumerable<BrandDTo>> GetAllBrandsAsync();

    }
}
