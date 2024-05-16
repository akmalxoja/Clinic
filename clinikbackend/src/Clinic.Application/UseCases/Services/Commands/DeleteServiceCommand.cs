using Clinic.Domain.DTOs;
using MediatR;

namespace Clinic.Application.UseCases.Services.Commands
{
    public class DeleteServiceCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
