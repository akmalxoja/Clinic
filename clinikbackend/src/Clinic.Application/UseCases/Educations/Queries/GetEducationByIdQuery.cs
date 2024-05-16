using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Educations.Queries
{
    public class GetEducationByIdQuery : IRequest<Education>
    {
        public Guid Id { get; set; }
    }
}
