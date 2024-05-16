using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Doctors.Commands
{
    public class UpdateDoctorCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StartWork { get; set; }
        public string TUsername { get; set; }
        public IFormFile? Picture { get; set; }
        public Guid SpecialistId { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
