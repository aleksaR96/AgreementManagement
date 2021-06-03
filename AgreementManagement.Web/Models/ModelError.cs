namespace AgreementManagement.Web.Models
{
    public class ModelError
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public ModelError(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
