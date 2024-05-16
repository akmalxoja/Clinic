using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.ServiceTypes.Queries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.UseCases.ServiceTypes.Handlers.QueryHandlers
{
    public class GetServiceTypeByIdQueryHandler : IRequestHandler<GetServiceTypeByIdQuery, ServiceType>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetServiceTypeByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ServiceType> Handle(GetServiceTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceType = await _clinincDbContext.ServiceTypes
                .Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (serviceType == null)
            {
                throw new Exception("Not Found");
            }
            return serviceType;

        }
    }
}
