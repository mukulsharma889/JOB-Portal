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
        public DbSet<Company> Company { get; set; }
        public DbSet<Location> Location { get; set; }

        private static readonly Guid AdminUserId = Guid.Parse("935e5a4d-a35f-491a-ba18-b58b5b3039f5");
        private static readonly Guid AdminRoleId = Guid.Parse("e2332a79-6607-4d9b-b08d-d39ee20fb0a0");
        private static readonly Guid ApplicantRoleId = Guid.Parse("9ceb6b18-0870-4cfc-bebf-94dee78ae15e");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserJobs>(entity =>
            {
                entity.HasKey(uj => new { uj.UserId, uj.JobId });

                entity.HasOne(uj => uj.User)
                      .WithMany(u => u.UserJobs)
                      .HasForeignKey(uj => uj.UserId);

                entity.HasOne(uj => uj.Job)
                      .WithMany(j => j.UserJobs)
                      .HasForeignKey(uj => uj.JobId);

                entity.ToTable("UserJobs");
            });


            builder.Entity<ApplicationUser>(x =>
            {
                x.ToTable("Users");
            });

            builder.Entity<IdentityRole<Guid>>(x =>
            {
                x.ToTable("Roles");
            });

            builder.Entity<IdentityUserRole<Guid>>(x =>
            {
                x.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<Guid>>(x =>
            {
                x.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<Guid>>(x =>
            {
                x.ToTable("UserLogin");
            });

            builder.Entity<IdentityRoleClaim<Guid>>(x =>
            {
                x.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<Guid>>(b =>
            {
                b.ToTable("UserTokens");
            });

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
                FirstName = "Mukul",
                LastName = "Sharma",    
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
