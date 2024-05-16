using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Specialist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        public bool isDeleted {  get; set; }
    }
}
