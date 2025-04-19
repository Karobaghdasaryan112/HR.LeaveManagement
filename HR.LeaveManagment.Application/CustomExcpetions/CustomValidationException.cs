using FluentValidation.Results;

namespace HR.LeaveManagment.Application.CustomExcpetions
{
    public class CustomValidationException : ApplicationException
    {

        public List<string> Errors { get; set; } = new List<string>();
        public CustomValidationException() : base("Validation error occurred.")
        {
        }

        public CustomValidationException(ValidationResult validationResult) 
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }

        public CustomValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
