using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        public bool IsDeleted { get; set; }
    }
}
