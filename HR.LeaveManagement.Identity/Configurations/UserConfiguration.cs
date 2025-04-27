

using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var ApplicationUser1PasswordHasher = "AQAAAAIAAYagAAAAEECgs9QwG2lC1h4GgxN+jp4Dfr4DZ0pYgpbXgmAS5v6yM2aAbPvD7pOe0T7Ml+w7Yw==";
            var ApplicationUser2PasswordHasher = "AQAAAAIAAYagAAAAEECgs9QwG2lC1h4GgxN+jp4Dfr4DZ0pYgpbXgmAS5v6yM2aAbPvD7pOe0T7Ml+w7Yw==";

            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "admin@localhost.com",
                     NormalizedUserName = "ADMIN@LOCALHOST.COM",
                     PasswordHash = ApplicationUser1PasswordHasher,
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user@localhost.com",
                     NormalizedUserName = "USER@LOCALHOST.COM",
                     PasswordHash = ApplicationUser2PasswordHasher,
                     EmailConfirmed = true
                 }
            );
        }
    }
}
