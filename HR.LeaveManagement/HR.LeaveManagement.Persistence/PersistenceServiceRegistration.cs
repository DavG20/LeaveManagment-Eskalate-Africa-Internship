using HR.LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddEntityFrameworkNpgsql()
            .AddDbContext<LeaveManagementDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("LeaveManagementConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)) ;
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }


    }
}
