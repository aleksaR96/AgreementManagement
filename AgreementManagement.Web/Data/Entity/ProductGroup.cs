using System;
using System.Collections.Generic;

namespace AgreementManagement.Web.Data
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Agreement = new HashSet<Agreement>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string GroupDescription { get; set; }
        public string GroupCode { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Agreement> Agreement { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
