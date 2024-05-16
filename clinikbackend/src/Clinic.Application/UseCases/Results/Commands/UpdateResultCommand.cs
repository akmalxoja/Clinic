using Clinic.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Results.Commands
{
    public class UpdateResultCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DoctorId { get; set; }
        public string PhotoBefore { get; set; }
        public string PhotoAfter { get; set; }
    }
}
