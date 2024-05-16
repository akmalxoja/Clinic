using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ServiceTypeId { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual ServiceType ServiceType { get; set; }

    }
}
