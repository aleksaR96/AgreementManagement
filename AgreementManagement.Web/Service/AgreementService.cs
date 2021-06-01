namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using System.Collections.Generic;

    public class AgreementService
    {
        private IRepository<Agreement> _agreementRepository;
        private IMapper _mapper;

        public AgreementService(IRepository<Agreement> agreementRepository, IMapper mapper)
        {
            _agreementRepository = agreementRepository;
            _mapper = mapper;
        }

        public List<AgreementDTO> GetAgreements()
        {
            List<Agreement> agreementList = (List<Agreement>)_agreementRepository.GetAll();
            List<AgreementDTO> dtoList = _mapper.Map<List<AgreementDTO>>(agreementList);
            return dtoList;
        }
    }
}
