namespace AgreementManagement.Web.Models.Home
{
    using System;

    public class AgreementTableModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public int ProductGroupCode { get; set; }
        public string ProductGroupDescription { get; set; }
        public string ProductNumber { get; set; }
        public string ProductDescription { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal NewPrice { get; set; }
    }
}
