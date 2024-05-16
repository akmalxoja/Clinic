using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Doctors.Queries
{
    public class GetDoctorByIdQuery:IRequest<Doctor>
    {
        public Guid Id { get; set; }
    }
}
