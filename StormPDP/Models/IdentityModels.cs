using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StormPDP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<DevelopmentPlan> DevelopmentPlans { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(es => new { es.EmployeeId, es.SkillId });

            modelBuilder.Entity<EmployeeSkill>()
                .HasRequired(es => es.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<EmployeeSkill>()
                .HasRequired(es => es.Skill)
                .WithMany(s => s.EmployeeSkills)
                .HasForeignKey(es => es.SkillId);

        }
    }
}