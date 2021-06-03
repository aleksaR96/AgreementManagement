namespace AgreementManagement.Web.Models
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Collections.Generic;
    using System.Linq;

    public static class ModelStateExtension
    {
        public static IEnumerable<ModelError> AllErrors(this ModelStateDictionary modelState)
        {
            var errorsResult = new List<ModelError>();
            var fields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var field in fields)
            {
                var fieldKey = field.Key;
                var fieldErrors = field.Errors
                                   .Select(error => new ModelError(fieldKey, error.ErrorMessage));
                errorsResult.AddRange(fieldErrors);
            }

            return errorsResult;
        }
    }
}
