

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

            var ApplicationUser1PasswordHasher = "AQAAAAIAAYagAAAAEMyGPi5LPdB5VDC2eAbBShYVE8YzZN2dhus4xDi6iM4bhOeX78oYcN/j3uewnb2ccQ==";
            var ApplicationUser2PasswordHasher = "AQAAAAIAAYagAAAAEOm+zQ7jdJvr2L7JqiqjLTLRy3RJhNB7lVgme9wdjK+Vxhc2jBjT3jSJXbWlyYwjWw==";

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
