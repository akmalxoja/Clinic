using Clinic.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Specialists.Commands
{
    public class DeleteSpecialistCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
