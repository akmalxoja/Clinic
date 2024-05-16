using Clinic.Application.UseCases.Educations.Commands;
using Clinic.Application.UseCases.Educations.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IMediator _mediatoR;

        public EducationController(IMediator mediatoR)
        {
            _mediatoR = mediatoR;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateEducation(CreateEducationCommand request)
        {
            return await _mediatoR.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<Education>> GetAllEducation(int pageIndex, int size)
        {
            return await _mediatoR.Send(new GetAllEducationsQuery
            {
                PageIndex = pageIndex,
                Size = size
            });
        }

        [HttpGet]
        public async Task<Education> GetEducationById(Guid Id)
        {
            return await _mediatoR.Send(new GetEducationByIdQuery
            {
                Id = Id
            });
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateEducation(UpdateEducationCommand request)
        {
            return await _mediatoR.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteEducation(DeleteEducationCommand request)
        {
            return await _mediatoR.Send(request);
        }
    }
}
