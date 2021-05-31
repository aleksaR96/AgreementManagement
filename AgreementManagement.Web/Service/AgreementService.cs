namespace AgreementManagement.Web.Service
{
    using AgreementManagement.Web.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class AgreementService
    {
        public List<Agreement> GetAgreements()
        {
            List<Agreement> agreementList;

            using (AgreementManagementContext context = new AgreementManagementContext())
            {
                agreementList = context.Agreement.ToList();
            }

            return agreementList;
        }
    }
}
