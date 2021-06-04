namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using System;

    public class UserService
    {
        private IRepository<AspNetUsers> _aspNetUsersRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public UserService(
            IRepository<AspNetUsers> aspNetUsersRepository,
            IMapper mapper,
            ILogger logger)
        {
            _aspNetUsersRepository = aspNetUsersRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public AspNetUsersDTO GetUser(string id)
        {
            _logger.LogDebug(this + ": Get User");

            try
            {
                AspNetUsers user = _aspNetUsersRepository.GetById(id);
                AspNetUsersDTO dtoUser = _mapper.Map<AspNetUsersDTO>(user);
                return dtoUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(this + " " + ex.Message);
                throw;
            }
        }
    }
}
