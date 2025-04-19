namespace HR.LeaveManagment.Application.CustomExcpetions
{
    public class CustomBadRequestExcpetion : ApplicationException
    {
        public CustomBadRequestExcpetion() : base("Bad request.")
        {
        }

        public CustomBadRequestExcpetion(string message) : base(message)
        {
        }

        public CustomBadRequestExcpetion(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
