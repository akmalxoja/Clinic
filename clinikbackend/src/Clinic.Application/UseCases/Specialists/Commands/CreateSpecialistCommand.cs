using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Specialists.Commands
{
    public class CreateSpecialistCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
}
