namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using System.Collections.Generic;

    public class UserService
    {
        private IRepository<AspNetUsers> _aspNetUsersRepository;
        private IMapper _mapper;

        public UserService(IRepository<AspNetUsers> aspNetUsersRepository, IMapper mapper)
        {
            _aspNetUsersRepository = aspNetUsersRepository;
            _mapper = mapper;
        }

        public List<AspNetUsersDTO> GetAgreements()
        {
            List<AspNetUsers> usersList = (List<AspNetUsers>)_aspNetUsersRepository.GetAll();
            List<AspNetUsersDTO> dtoList = _mapper.Map<List<AspNetUsersDTO>>(usersList);
            return dtoList;
        }
    }
}
