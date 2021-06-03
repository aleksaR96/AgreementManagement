namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Models.Home;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public void AddAgreementFromForm(
            AgreementModel agreement,
            IRepository<AspNetUsers> usersRepository,
            IRepository<Product> productRepository,
            IRepository<Agreement> agreementRepository)
        {
            try
            {
                AspNetUsers user = usersRepository.GetAll().FirstOrDefault(u => u.UserName == agreement.UserName);
                Product product = productRepository.GetById(agreement.ProductId);

                Agreement newAgreement = new Agreement
                {
                    UserId = user.Id,
                    ProductGroupId = agreement.ProductGroupId,
                    ProductId = agreement.ProductId,
                    EffectiveDate = agreement.EffectiveDate,
                    ExpirationDate = agreement.ExpirationDate,
                    ProductPrice = product.Price,
                    NewPrice = agreement.NewPrice
                };

                agreementRepository.Insert(newAgreement);
                agreementRepository.Save();
                agreementRepository.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditAgreementFromForm(
            AgreementModel agreement,
            IRepository<AspNetUsers> usersRepository,
            IRepository<Product> productRepository,
            IRepository<Agreement> agreementRepository)
        {
            try
            {
                AspNetUsers user = usersRepository.GetAll().FirstOrDefault(u => u.UserName == agreement.UserName);
                Product product = productRepository.GetById(agreement.ProductId);

                Agreement newAgreement = new Agreement
                {
                    Id = (int)agreement.Id,
                    UserId = user.Id,
                    ProductGroupId = agreement.ProductGroupId,
                    ProductId = agreement.ProductId,
                    EffectiveDate = agreement.EffectiveDate,
                    ExpirationDate = agreement.ExpirationDate,
                    ProductPrice = product.Price,
                    NewPrice = agreement.NewPrice
                };

                agreementRepository.Update(newAgreement);
                agreementRepository.Save();
                agreementRepository.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveAgreement(int id)
        {
            _agreementRepository.Delete(id);
            _agreementRepository.Save();
            _agreementRepository.Dispose();
        }
    }
}
