namespace AgreementManagement.Web.Models.Home
{
    using System;

    public class AgreementModel
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public int ProductGroupId { get; set; }
        public int ProductId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal NewPrice { get; set; }
        public bool Active { get; set; }
    }
}
