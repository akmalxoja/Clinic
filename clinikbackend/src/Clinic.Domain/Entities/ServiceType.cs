using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class ServiceType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Service> Services { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
    }
}
