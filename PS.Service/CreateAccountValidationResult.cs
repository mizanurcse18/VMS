using System.Collections.Generic;

namespace PS.Service
{
    public class CreateAccountValidationResult
    {
        public List<CreateAccountValidationError> ValidationErrors { get; set; }
        public long UserId { get; set; }

        public bool IsValid
        {
            get { return ValidationErrors.Count == 0; }
        }

        public CreateAccountValidationResult()
        {
            ValidationErrors = new List<CreateAccountValidationError>();
        }
    }
}