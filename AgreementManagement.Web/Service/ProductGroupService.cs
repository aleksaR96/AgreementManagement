﻿namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using System.Collections.Generic;

    public class ProductGroupService
    {
        private IRepository<ProductGroup> _productGroupRepository;
        private IMapper _mapper;

        public ProductGroupService(IRepository<ProductGroup> productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public List<ProductGroupDTO> GetProducts()
        {
            List<ProductGroup> productGroupsList = (List<ProductGroup>)_productGroupRepository.GetAll();
            List<ProductGroupDTO> dtoList = _mapper.Map<List<ProductGroupDTO>>(productGroupsList);
            return dtoList;
        }
    }
}
