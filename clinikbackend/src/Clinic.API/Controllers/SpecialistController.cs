using Clinic.Application.UseCases.Specialist.Queries;
using Clinic.Application.UseCases.Specialists.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public SpecialistController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateSpecialist(CreateSpecialistCommand request)
        {
            return await _mediatR.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<Specialist>> GetAllSpecialist(int pageIndex,int size)
        {
            return await _mediatR.Send(new GetAllSpecialistsQuery
            {
                PageIndex = pageIndex,
                Size = size
            });
        }

        [HttpGet]
        public async Task<Specialist> GetSpecialistById(Guid id)
        {
            return await _mediatR.Send(new GetSpecialistByIdQuery
            {
                Id = id
            });
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateSpecialist(UpdateSpecialistCommand request)
        {
            return await _mediatR.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteSpecialist(DeleteSpecialistCommand request)
        {
            return await _mediatR.Send(request);
        }
    }
}
