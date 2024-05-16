using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Diploms.Commands
{
    public class CreateDiplomCommand : IRequest<ResponseModel>
    {
        public string LitsenzyaId { get; set; }
        public Guid DoctorId { get; set; }
        public IFormFile? Picture { get; set; }
    }   
}
