namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using System.Collections.Generic;

    public class ProductService
    {
        private IRepository<Product> _productRepository;
        private IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<ProductDTO> GetProducts()
        {
            List<Product> productList = (List<Product>)_productRepository.GetAll();
            List<ProductDTO> dtoList = _mapper.Map<List<ProductDTO>>(productList);
            return dtoList;
        }

        public ProductDTO GetProduct(int id)
        {
            Product product = _productRepository.GetById(id);
            ProductDTO dtoProduct = _mapper.Map<ProductDTO>(product);
            return dtoProduct;
        }
    }
}
