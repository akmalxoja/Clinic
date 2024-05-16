using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Specialist.Queries
{
    public class GetSpecialistByIdQuery : IRequest<Domain.Entities.Specialist>
    {
        public Guid Id { get; set; }
    }
}
