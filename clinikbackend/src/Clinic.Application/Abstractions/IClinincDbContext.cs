using Clinic.Domain.Entities;
using Clinic.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.Abstractions
{
    public interface IClinincDbContext
    {
        public DbSet<Diplom> Diploms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Specialist> Specialists { get; set; }

        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
    }
}
