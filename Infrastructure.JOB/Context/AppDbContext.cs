using Domain.JOB.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.JOB.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<UserJobs> UserJobs { get; set; }

        private static readonly Guid AdminUserId = Guid.Parse("935e5a4d-a35f-491a-ba18-b58b5b3039f5");
        private static readonly Guid AdminRoleId = Guid.Parse("e2332a79-6607-4d9b-b08d-d39ee20fb0a0");
        private static readonly Guid ApplicantRoleId = Guid.Parse("9ceb6b18-0870-4cfc-bebf-94dee78ae15e");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserJobs>()
                .HasKey(x => new { x.UserId, x.JobId });

            SeedRoles(builder);
            SeedAdminUser(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            var roles = new List<IdentityRole<Guid>>
            {
                new()
                {
                    Id = AdminRoleId,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = AdminRoleId.ToString()
                },
                new()
                {
                    Id = ApplicantRoleId,
                    Name = "applicant",
                    NormalizedName = "APPLICANT",
                    ConcurrencyStamp = ApplicantRoleId.ToString()
                }
            };

            builder.Entity<IdentityRole<Guid>>().HasData(roles);
        }

        private static void SeedAdminUser(ModelBuilder builder)
        {
            var adminUser = new ApplicationUser
            {
                Id = AdminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "smukul889@gmail.com",
                NormalizedEmail = "SMUKUL889@GMAIL.COM",
                PhoneNumber = "7465915545",
                SecurityStamp = AdminUserId.ToString(),
                ConcurrencyStamp = AdminUserId.ToString()
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "User1@123");

            builder.Entity<ApplicationUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                UserId = AdminUserId,
                RoleId = AdminRoleId
            });
        }
    }
}
