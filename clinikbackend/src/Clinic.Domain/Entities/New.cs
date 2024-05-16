using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class New
    {
        public Guid Id { get; set; }
        public string PicturePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }


        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public bool IsDeleted { get; set; }
    }
}
