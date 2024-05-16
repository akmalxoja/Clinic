using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Clinic.Application.UseCases.Doctors.Commands
{
    public class CreateDoctorCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int StartWork { get; set; }
        public string TUsername { get; set; }
        public IFormFile? Picture { get; set; }
        public Guid SpecialistId { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
