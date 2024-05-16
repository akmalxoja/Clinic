using Clinic.Application.UseCases.Educations.Commands;
using Clinic.Application.UseCases.Educations.Queries;
using Clinic.Application.UseCases.ServiceTypes.Commands;
using Clinic.Application.UseCases.ServiceTypes.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IMediator _mediatoR;

        public ServiceTypeController(IMediator mediatoR)
        {
            _mediatoR = mediatoR;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateServiceType(CreateServiceTypeCommand request)
        {
            return await _mediatoR.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceType>> GetAllServiceType(int pageIndex, int size)
        {
            return await _mediatoR.Send(new GetAllServiceTypesQuery
            {
                PageIndex = pageIndex,
                Size = size
            });
        }

        [HttpGet]
        public async Task<ServiceType> GetServiceTypeById(Guid Id)
        {
            return await _mediatoR.Send(new GetServiceTypeByIdQuery
            {
                Id = Id
            });
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateServiceType(UpdateServiceTypeCommand request)
        {
            return await _mediatoR.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteServiceType(DeleteServiceTypeCommand request)
        {
            return await _mediatoR.Send(request);
        }
    }
}
