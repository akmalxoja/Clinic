using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Results.Commands
{
    public class CreateResultCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public IFormFile PhotoBefore { get; set; }
        public IFormFile PhotoAfter { get; set; }
        public Guid DoctorId { get; set; }
    }
}
