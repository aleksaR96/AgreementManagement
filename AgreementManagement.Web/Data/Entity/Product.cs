using System;
using System.Collections.Generic;

namespace AgreementManagement.Web.Data
{
    public partial class Product
    {
        public Product()
        {
            Agreement = new HashSet<Agreement>();
        }

        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumber { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }

        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ICollection<Agreement> Agreement { get; set; }
    }
}
