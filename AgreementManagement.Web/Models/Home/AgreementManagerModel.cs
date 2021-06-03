namespace AgreementManagement.Web.Models.Home
{
    using AgreementManagement.Web.Service.DTO;
    using System.Collections.Generic;

    public class AgreementManagerModel
    {
        public List<ProductGroupDTO> ProductGroupList { get; set; }
        public List<ProductDTO> ProductList { get; set; }
    }
}
