using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StartWork { get; set; }
        public string TUsername { get; set; }
        public bool IsDeleted { get; set; }
        public string? PicturePath { get; set; }
        public Guid SpecialistId { get; set; }
        public Guid ServiceTypeId { get; set; }
        public virtual Specialist Specialist { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual List<Result> Results { get; set; }
        public virtual List<Education> Educations { get; set; }
        public virtual List<Diplom> Diploms { get; set; }
        public virtual List<Skill> Skills { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
    }
}
