using Clinic.Domain.Entities.Auth;

namespace Clinic.Domain.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public string? VideoPath { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTimeOffset WritedDate { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Service Service { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
