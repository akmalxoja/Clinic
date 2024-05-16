using Clinic.Domain.Entities;
using MediatR;

namespace Clinic.Application.UseCases.Services.Queries
{
    public class GetAllServicesQuery : IRequest<IEnumerable<Service>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; }
    }
}
