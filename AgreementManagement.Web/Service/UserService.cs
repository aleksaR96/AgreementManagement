namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;

    public class UserService
    {
        private IRepository<AspNetUsers> _aspNetUsersRepository;
        private IMapper _mapper;

        public UserService(IRepository<AspNetUsers> aspNetUsersRepository, IMapper mapper)
        {
            _aspNetUsersRepository = aspNetUsersRepository;
            _mapper = mapper;
        }

        public AspNetUsersDTO GetUser(string id)
        {
            AspNetUsers user = _aspNetUsersRepository.GetById(id);
            AspNetUsersDTO dtoUser = _mapper.Map<AspNetUsersDTO>(user);
            return dtoUser;
        }
    }
}
