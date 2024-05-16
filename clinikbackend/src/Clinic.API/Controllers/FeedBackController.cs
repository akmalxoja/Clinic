using Clinic.Application.UseCases.Educations.Commands;
using Clinic.Application.UseCases.Educations.Queries;
using Clinic.Application.UseCases.Feedbacks.Commands;
using Clinic.Application.UseCases.Feedbacks.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IMediator _mediatoR;

        public FeedBackController(IMediator mediatoR)
        {
            _mediatoR = mediatoR;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateFeedback(CreateFeedbackCommand request)
        {
            return await _mediatoR.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<Feedback>> GetAllFeedback(int pageIndex, int size)
        {
            return await _mediatoR.Send(new GetAllFeedbacksQuery
            {
                PageIndex = pageIndex,
                Size = size
            });
        }

        [HttpGet]
        public async Task<Feedback> GetFeedbackById(Guid Id)
        {
            return await _mediatoR.Send(new GetFeedbackByIdQuery
            {
                Id = Id
            });
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateFeedback(UpdateFeedbackCommand request)
        {
            return await _mediatoR.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteFeedback(DeleteFeedbackCommand request)
        {
            return await _mediatoR.Send(request);
        }

    }
}
