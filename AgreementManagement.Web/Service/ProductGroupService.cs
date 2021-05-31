namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductGroupService
    {
        private IRepository<ProductGroup> _productGroupRepository;

        public ProductGroupService(IRepository<ProductGroup> productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public List<ProductGroup> GetProductGroups()
        {
            List<ProductGroup> productGroups = (List<ProductGroup>)_productGroupRepository.GetAll();
            _productGroupRepository.Save();
            _productGroupRepository.Dispose();

            return productGroups;
        }
    }
}
