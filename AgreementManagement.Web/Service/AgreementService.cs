namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Models.Home;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AgreementService
    {
        private IRepository<Agreement> _agreementRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public AgreementService(
            IRepository<Agreement> agreementRepository,
            IMapper mapper,
            ILogger logger)
        {
            _agreementRepository = agreementRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public List<AgreementDTO> GetAgreements()
        {
            _logger.LogDebug(this + ": Get Agreements");

            try
            {
                List<Agreement> agreementList = (List<Agreement>)_agreementRepository.GetAll();
                List<AgreementDTO> dtoList = _mapper.Map<List<AgreementDTO>>(agreementList);
                return dtoList;
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }

        public void AddAgreementFromForm(
            AgreementModel agreement,
            IRepository<AspNetUsers> usersRepository,
            IRepository<Product> productRepository,
            IRepository<Agreement> agreementRepository)
        {
            _logger.LogDebug(this + ": Add Agreement From Form");

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
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }

        public void EditAgreementFromForm(
            AgreementModel agreement,
            IRepository<AspNetUsers> usersRepository,
            IRepository<Product> productRepository,
            IRepository<Agreement> agreementRepository)
        {
            _logger.LogDebug(this + ": Edit Agreement From Form");

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
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }

        public void RemoveAgreement(int id)
        {
            _logger.LogDebug(this + ": Remove Agreement");

            try
            {
                _agreementRepository.Delete(id);
                _agreementRepository.Save();
                _agreementRepository.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }
    }
}
