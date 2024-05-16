using Clinic.Domain.Entities;
using MediatR;

namespace Clinic.Application.UseCases.Services.Queries
{
    public class GetByIdServiceQuery:IRequest<Service>
    {
        public Guid Id { get; set; }
    }
}
