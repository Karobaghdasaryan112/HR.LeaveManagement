using HR.LeaveManagment.Application.Models.Identity.Auth;
using HR.LeaveManagment.Application.Models.Identity.Registration;

namespace HR.LeaveManagment.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(AuthRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
