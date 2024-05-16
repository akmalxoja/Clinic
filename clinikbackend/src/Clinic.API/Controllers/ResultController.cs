using Clinic.Application.UseCases.Results.Commands;
using Clinic.Application.UseCases.Results.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ResultController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateSkills(CreateResultCommand request)
        {
            return await _mediatr.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<Result>> GetAllSkills(int pageIndex, int size)
        {
            return await _mediatr.Send(new GetAllResultsQuery
            {
                PageIndex= pageIndex,
                Size= size
            });
        }

        [HttpGet]
        public async Task<Result> GetSkillById(Guid Id)
        {
            return await _mediatr.Send(new GetResultByIdQuery
            {
                Id = Id
            });
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateSkill(UpdateResultCommand request)
        {
            return await _mediatr.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteSkill(DeleteResultCommand request)
        {
            return await _mediatr.Send(request);
        }
    }
}
