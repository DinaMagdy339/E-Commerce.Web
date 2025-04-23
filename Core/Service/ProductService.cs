using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction;
using Shared.DataTransferObjects;
using Service.Specifications;

using System;
namespace Service
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDTo>> GetAllBrandsAsync()
        {
            var Repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var Brands = await Repo.GetAllAsync();
            var BrandsDto = _mapper.Map < IEnumerable<ProductBrand>, IEnumerable< BrandDTo >> (Brands);
            return BrandsDto;
        }

        public async Task<IEnumerable<ProductDTo>> GetAllProductsAsync()
        {
            var Specification = new ProductWithBrandAndTypeSpecification();
            var Products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(Specification);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTo>>(Products);

        }

        public async Task<IEnumerable<TypeDTo>> GetAllTypessAsync()
        {
            var Types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var TypesDto = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDTo>>(Types);
            return TypesDto;
        }

        public async Task<ProductDTo> GetProductByIdAsync(int id)
        {
            var Specification = new ProductWithBrandAndTypeSpecification(id);
            var Product =await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(Specification);
            return _mapper.Map<Product, ProductDTo>(Product);
        }
    }
}
