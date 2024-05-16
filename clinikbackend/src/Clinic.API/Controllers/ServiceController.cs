using Clinic.Application.UseCases.Services.Commands;
using Clinic.Application.UseCases.Services.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ServiceController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateService(CreateServiceCommand request)
        {
            return await _mediatr.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<Service>> GetAllServices(int pageIndex,int size)
        {
            var s =  await _mediatr.Send(new GetAllServicesQuery()
            {
                PageIndex= pageIndex,
                Size=size
            });
            return s;
        }

        [HttpGet]
        public async Task<Service> GetServiceById(Guid id)
        {
            return await _mediatr.Send(new GetByIdServiceQuery { Id = id }) ;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateService(UpdateServiceCommand request)
        {
            return await _mediatr.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteService(DeleteServiceCommand request)
        {
            return await _mediatr.Send(request);
        }
    }
}
