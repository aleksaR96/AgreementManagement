namespace AgreementManagement.Web.Controllers.Helpers
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Models.Home;
    using AgreementManagement.Web.Service;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    public class HomeHelper
    {
        private readonly IRepository<ProductGroup> _productGroupRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Agreement> _agreementRepository;
        private readonly IRepository<AspNetUsers> _aspNetUsersRepository;
        private readonly IMapper _mapper;
        private ILogger _logger;

        public HomeHelper(
            IRepository<ProductGroup> productGroupRepository,
            IRepository<Product> productRepository,
            IRepository<Agreement> agreementRepository,
            IRepository<AspNetUsers> aspNetUsersRepository,
            IMapper mapper,
            ILogger logger)
        {
            _productGroupRepository = productGroupRepository;
            _productRepository = productRepository;
            _agreementRepository = agreementRepository;
            _aspNetUsersRepository = aspNetUsersRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public AgreementManagerModel PrepareAgreementManagerModel()
        {
            _logger.LogDebug(this + ": Prepare Agreement Manager Model");

            try
            {
                ProductService productService = new ProductService(_productRepository, _mapper, _logger);
                ProductGroupService productGroupService = new ProductGroupService(_productGroupRepository, _mapper, _logger);

                List<ProductGroupDTO> productGroups = productGroupService.GetProductGroups();
                List<ProductDTO> products = productService.GetProducts();

                return new AgreementManagerModel
                {
                    ProductGroupList = productGroups,
                    ProductList = products
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }

        public List<AgreementTableModel> PrepareAgreementTableModel()
        {
            _logger.LogDebug(this + ": Prepare Agreement Table Model");

            try
            {
                AgreementService agreementService = new AgreementService(_agreementRepository, _mapper, _logger);
                UserService userService = new UserService(_aspNetUsersRepository, _mapper, _logger);
                ProductService productService = new ProductService(_productRepository, _mapper, _logger);
                ProductGroupService productGroupService = new ProductGroupService(_productGroupRepository, _mapper, _logger);

                List<AgreementDTO> agreementList = agreementService.GetAgreements();
                List<AgreementTableModel> tableModelList = new List<AgreementTableModel>();

                foreach (var item in agreementList)
                {
                    var user = userService.GetUser(item.UserId);
                    var productGroup = productGroupService.GetProductGroup(item.ProductGroupId);
                    var product = productService.GetProduct(item.ProductId);

                    tableModelList.Add(new AgreementTableModel
                    {
                        Id = item.Id,
                        UserName = user.UserName,
                        ProductGroupCode = productGroup.Id,
                        ProductGroupDescription = productGroup.GroupDescription,
                        ProductNumber = product.ProductNumber,
                        ProductDescription = product.ProductDescription,
                        ProductId = product.Id,
                        EffectiveDate = item.EffectiveDate,
                        ExpirationDate = item.ExpirationDate,
                        ProductPrice = item.ProductPrice,
                        NewPrice = item.NewPrice
                    });
                }

                return tableModelList;
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }
    }
}
