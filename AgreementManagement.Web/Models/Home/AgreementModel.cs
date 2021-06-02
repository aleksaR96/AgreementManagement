namespace AgreementManagement.Web.Models.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AgreementModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Product Group field is required")]
        public int ProductGroupId { get; set; }
        [Required(ErrorMessage = "Product field is required")]
        public int ProductId { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        public decimal ProductPrice { get; set; }
        [Required(ErrorMessage = "New Price field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public decimal NewPrice { get; set; }
        public bool Active { get; set; }
    }
}
