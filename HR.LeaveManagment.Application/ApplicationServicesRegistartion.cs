using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR.LeaveManagment.Application
{
    public static class ApplicationServicesRegistartion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(LeaveTypeDto)));

            services.AddTransient<ICommandResponse,BaseCommandResponse>();

            var assemblies = new[] {
            typeof(LeaveAllocationDto).Assembly,
            typeof(LeaveRequestDto).Assembly,
            typeof(LeaveTypeDto).Assembly
            };

            services.AddValidatorsFromAssemblies(assemblies);

            return services;
        }
    }
}
