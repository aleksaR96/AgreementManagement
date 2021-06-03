namespace AgreementManagement.Web.Controllers.Helpers
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Models.Home;
    using AgreementManagement.Web.Service;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using System.Collections.Generic;

    public class HomeHelper
    {
        private readonly IRepository<ProductGroup> _productGroupRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Agreement> _agreementRepository;
        private readonly IRepository<AspNetUsers> _aspNetUsersRepository;
        private readonly IMapper _mapper;

        public HomeHelper(
            IRepository<ProductGroup> productGroupRepository,
            IRepository<Product> productRepository,
            IRepository<Agreement> agreementRepository,
            IRepository<AspNetUsers> aspNetUsersRepository,
            IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _productRepository = productRepository;
            _agreementRepository = agreementRepository;
            _aspNetUsersRepository = aspNetUsersRepository;
            _mapper = mapper;
        }

        public AgreementManagerModel PrepareAgreementManagerModel()
        {
            ProductService productService = new ProductService(_productRepository, _mapper);
            ProductGroupService productGroupService = new ProductGroupService(_productGroupRepository, _mapper);

            List<ProductGroupDTO> productGroups = productGroupService.GetProductGroups();
            List<ProductDTO> products = productService.GetProducts();

            return new AgreementManagerModel
            {
                ProductGroupList = productGroups,
                ProductList = products
            };
        }

        public List<AgreementTableModel> PrepareAgreementTableModel()
        {
            AgreementService agreementService = new AgreementService(_agreementRepository, _mapper);
            UserService userService = new UserService(_aspNetUsersRepository, _mapper);
            ProductService productService = new ProductService(_productRepository, _mapper);
            ProductGroupService productGroupService = new ProductGroupService(_productGroupRepository, _mapper);

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
    }
}
