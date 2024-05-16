using Clinic.Domain.DTOs;
using MediatR;

namespace Clinic.Application.UseCases.Feedbacks.Commands
{
    public class DeleteFeedbackCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
