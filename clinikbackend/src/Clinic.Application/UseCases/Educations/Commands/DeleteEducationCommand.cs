using Clinic.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Educations.Commands
{
    public class DeleteEducationCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
