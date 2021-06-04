namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    public class ProductService
    {
        private IRepository<Product> _productRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public ProductService(IRepository<Product> productRepository,
            IMapper mapper,
            ILogger logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public List<ProductDTO> GetProducts()
        {
            _logger.LogDebug(this + ": Get Products");

            try
            {
                List<Product> productList = (List<Product>)_productRepository.GetAll();
                List<ProductDTO> dtoList = _mapper.Map<List<ProductDTO>>(productList);
                return dtoList;
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }

        public ProductDTO GetProduct(int id)
        {
            _logger.LogDebug(this + ": Get Product");

            try
            {
                Product product = _productRepository.GetById(id);
                ProductDTO dtoProduct = _mapper.Map<ProductDTO>(product);
                return dtoProduct;
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }
    }
}
