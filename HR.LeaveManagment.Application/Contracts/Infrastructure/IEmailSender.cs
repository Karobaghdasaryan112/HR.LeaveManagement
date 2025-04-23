using HR.LeaveManagment.Application.Models;

namespace HR.LeaveManagment.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
