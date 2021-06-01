namespace AgreementManagement.Web.Controllers.Helpers
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Models.Home;
    using AgreementManagement.Web.Service;
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

        public List<AgreementTableModel> PrepareAgreementTableModel()
        {
            var agrService = new AgreementService(_agreementRepository, _mapper);
            var list = agrService.GetAgreements();

            return new List<AgreementTableModel>();
        }
    }
}
