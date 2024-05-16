using Clinic.Application.UseCases.Diploms.Commands;
using Clinic.Application.UseCases.Diploms.Quries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiplomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DiplomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateDiplom([FromBody] CreateDiplomCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<Diplom>> GetAllDiplom(int pageIndex, int size)
        {
            return await _mediator.Send(new GetAllDiplomsQuery
            {
                PageIndex = pageIndex,
                Size = size
            });
        }

        [HttpGet]
        public async Task<Diplom> GetDiblomById(Guid id)
        {
            return await _mediator.Send(new GetDiplomByIdQuery
            {
                Id = id
            });
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateDiplom(UpdateDiplomCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseModel> DeleteDiplom(Guid id)
        {
            return await _mediator.Send(new DeleteDiplomCommand()
            {
                Id = id
            });
        }
    }
}
