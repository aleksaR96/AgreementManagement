namespace AgreementManagement.Web.Service.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int? ProductGroupId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumber { get; set; }
        public decimal? Price { get; set; }
        public bool? Active { get; set; }
    }
}
