using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email,string password);
        Task<RegistrationResponse> Register(string email,string password,string firstName,string LastName,string userName);

        Task LogOut();
    }
}
