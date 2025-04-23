using HR.LeaveManagment.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagment.Persistance.DBContextConfiguration
{
    public static class SaveChangesAsync 
    {
        public static void ApplySaveChangesConfiguration(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DataCreated = DateTime.Now;
                }
            }
        }
    }
}
