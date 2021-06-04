namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    public class ProductGroupService
    {
        private IRepository<ProductGroup> _productGroupRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public ProductGroupService(
            IRepository<ProductGroup> productGroupRepository,
            IMapper mapper,
            ILogger logger)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public List<ProductGroupDTO> GetProductGroups()
        {
            _logger.LogDebug(this + ": Get Product Groups");

            try
            {
                List<ProductGroup> productGroupsList = (List<ProductGroup>)_productGroupRepository.GetAll();
                List<ProductGroupDTO> dtoList = _mapper.Map<List<ProductGroupDTO>>(productGroupsList);
                return dtoList;
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }

        public ProductGroupDTO GetProductGroup(int id)
        {
            _logger.LogDebug(this + ": Get Product Group");

            try
            {
                ProductGroup productGroup = _productGroupRepository.GetById(id);
                ProductGroupDTO dtoGroup = _mapper.Map<ProductGroupDTO>(productGroup);
                return dtoGroup;
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }
    }
}
