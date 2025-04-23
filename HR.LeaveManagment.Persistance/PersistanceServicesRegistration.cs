using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagment.Persistance
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connetionString = 
                configuration.GetConnectionString("LeaveManagementConnectionString");
            services.AddDbContext<LeaveManagementDbContext>(options =>
                options.UseSqlServer(connetionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
