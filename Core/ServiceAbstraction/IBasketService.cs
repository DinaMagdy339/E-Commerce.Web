using Shared.DataTransferObjects.BasketModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IBasketService
    {
        Task<BasketDTo> GetBaskitAsync(string Key);
        Task<BasketDTo> CreateOrUpdateBasketAsync(BasketDTo basket);
        Task<bool> DeleteBasketAsync(string Key);
    }
}
