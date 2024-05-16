using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Result
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhotoBefore { get; set; }
        public string PhotoAfter { get; set; }
        public bool IsDeleted { get; set; } 
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
