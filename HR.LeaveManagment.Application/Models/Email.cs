namespace HR.LeaveManagment.Application.Models
{
    public class Email
    {
        public string To;
        public string Subject;
        public string Body;

        public Email(string to, string subject, string body)
        {
            this.To = to;
            this.Subject = subject;
            this.Body = body;
        }
    }
}
