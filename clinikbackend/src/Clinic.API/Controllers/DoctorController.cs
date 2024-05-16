using Clinic.Application.UseCases.Doctors.Commands;
using Clinic.Application.UseCases.Doctors.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public DoctorController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateDoctor(CreateDoctorCommand request)
        {
            return await _mediatr.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetAllDoctor(int pageIndex, int size)
        {
            return await _mediatr.Send(new GetAllDoctorsQuery()
            {
                PageIndex = pageIndex,
                Size = size
            });
        }

        [HttpGet]
        public async Task<Doctor> GetDoctorById(Guid Id)
        {
            return await _mediatr.Send(new GetDoctorByIdQuery()
            {
                Id = Id
            });
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateDoctor(UpdateDoctorCommand request)
        {
            return await _mediatr.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteDoctor(DeleteDoctorCommand request)
        {
            return await _mediatr.Send(request);
        }
    }
}
