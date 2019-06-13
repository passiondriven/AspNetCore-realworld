﻿using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class CompareService : ICompareService
    {
        private readonly ICompareRepository _compareRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<CompareService> _logger;

        public CompareService(ICompareRepository compareRepository, IProductRepository productRepository, IAppLogger<CompareService> logger)
        {
            _compareRepository = compareRepository ?? throw new ArgumentNullException(nameof(compareRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }        

        public async Task<CompareModel> GetCompareByUserName(string userName)
        {
            var compare = await GetExistingOrCreateNewCompare(userName);
            var compareModel = ObjectMapper.Mapper.Map<CompareModel>(compare);
            
            foreach (var item in compare.ProductCompares)
            {
                var product = await _productRepository.GetProductByIdWithCategoryAsync(item.ProductId);
                var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);
                compareModel.Items.Add(productModel);
            }
            return compareModel;
        }

        public async Task AddItem(string userName, int productId)
        {
            var compare = await GetExistingOrCreateNewCompare(userName);
            compare.AddItem(productId);
            await _compareRepository.UpdateAsync(compare);            
        }

        public async Task RemoveItem(int CompareId, int productId)
        {
            var spec = new CompareWithItemsSpecification(CompareId);
            var compare = (await _compareRepository.GetAsync(spec)).FirstOrDefault();
            compare.RemoveItem(productId);
            await _compareRepository.UpdateAsync(compare);
        }

        private async Task<Compare> GetExistingOrCreateNewCompare(string userName)
        {
            var compare = await _compareRepository.GetByUserNameAsync(userName);
            if (compare != null)
                return compare;

            // if it is first attempt create new
            var newCompare = new Compare
            {
                UserName = userName
            };

            await _compareRepository.AddAsync(newCompare);
            return newCompare;
        }

    }
}
