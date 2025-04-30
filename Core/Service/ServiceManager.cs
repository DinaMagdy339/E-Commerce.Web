using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper , IBasketRepository basketRepository) : IServiceManager
    {
        private readonly Lazy<IProductService> _LazyproductService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
        private readonly Lazy<IBasketService> _LazybasketService = new Lazy<IBasketService>(() => new BasketService(basketRepository, mapper));

        public IProductService ProductService => _LazyproductService.Value;

        public IBasketService BasketService => _LazybasketService.Value;
    }
}
