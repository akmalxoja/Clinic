using Clinic.Domain.DTOs;
using MediatR;

namespace Clinic.Application.UseCases.Services.Commands
{
    public class CreateServiceCommand:IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
