 namespace Clinic.Domain.Entities
{
    public class Diplom
    {
        public Guid Id { get; set; }
        public string LitsenzyaId { get; set; }
        public string PicturePath { get; set; }
        public bool IsDeleted { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
