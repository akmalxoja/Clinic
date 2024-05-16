using Clinic.Application.UseCases.News.Commands;
using Clinic.Application.UseCases.News.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        private readonly IMediator _mediatoR;

        public NewController(IMediator mediatoR)
        {
            _mediatoR = mediatoR;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateNews(CreateNewsCommand request)
        {
            return await _mediatoR.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<New>> GetAllNews(int pageIndex, int size)
        {
            return await _mediatoR.Send(new GetAllNewsQuery
            {
                PageIndex = pageIndex,
                Size = size
            });
        }

        [HttpGet]
        public async Task<New> GetNewsById(Guid Id)
        {
            return await _mediatoR.Send(new GetNewsByIdQuery
            {
                Id = Id
            });
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateNews(UpdateNewsCommand request)
        {
            return await _mediatoR.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteNews(DeleteNewsCommand request)
        {
            return await _mediatoR.Send(request);
        }
    }
}
