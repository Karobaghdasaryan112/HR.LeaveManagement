using HR.LeaveManagment.Application.Models.Identity;

namespace HR.LeaveManagment.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(string userId);
    }
}
