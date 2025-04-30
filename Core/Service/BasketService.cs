using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.BasketModule;
using ServiceAbstraction;
using Shared.DataTransferObjects.BasketModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BasketService(IBasketRepository basketRepository ,IMapper mapper) : IBasketService
    {
        public async Task<BasketDTo> CreateOrUpdateBasketAsync(BasketDTo basket)
        {
             var customerBasket = mapper.Map<BasketDTo, CustomerBasket>(basket);
            var ISCreatedOrUpdated = basketRepository.CreateOrUpdateBasketAsync(customerBasket);
            if (ISCreatedOrUpdated is not null)
                return await GetBaskitAsync(basket.Id);
            else
                throw new Exception ("Can Not Create Or Update Basket Now , Try Again Later");
        }

        public async Task<bool> DeleteBasketAsync(string Key) => await basketRepository.DeleteBasketAsync(Key);


        public async Task<BasketDTo> GetBaskitAsync(string Key)
        {
            var basket = await basketRepository.GetBasketAsync(Key);
            if (basket is not null)
                return mapper.Map<CustomerBasket, BasketDTo>(basket);
            else
                throw new BasketNotFoundException(Key);


        }
    }
}
