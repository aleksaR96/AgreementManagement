namespace AgreementManagement.Web.Service.Mapper
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Service.DTO;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Agreement, AgreementDTO>()
                .ReverseMap();

            CreateMap<ProductGroup, ProductGroupDTO>()
                .ReverseMap();

            CreateMap<Product, ProductDTO>()
                .ReverseMap();

            CreateMap<AspNetUsers, AspNetUsersDTO>()
                .ReverseMap();
        }
    }
}
