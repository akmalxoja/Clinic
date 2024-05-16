using Clinic.Domain.DTOs;
using MediatR;

namespace Clinic.Application.UseCases.Services.Commands
{
    public class UpdateServiceCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
