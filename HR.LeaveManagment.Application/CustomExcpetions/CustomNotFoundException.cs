namespace HR.LeaveManagment.Application.CustomExcpetions
{
    public class CustomNotFoundException : ApplicationException
    {
        public CustomNotFoundException() : base("Not found.")
        {
        }

        public CustomNotFoundException(string message) : base(message)
        {
        }

        public CustomNotFoundException(string name, object key) : base($"{name} ({key}) was not found")
        {

        }

    }
}
