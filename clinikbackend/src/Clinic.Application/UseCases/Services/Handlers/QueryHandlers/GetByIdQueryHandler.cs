using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Services.Queries;
using Clinic.Domain.Entities;
using MediatR;

namespace Clinic.Application.UseCases.Services.Handlers.QueryHandlers
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdServiceQuery, Service>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<Service> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _clinincDbContext.Services.Where(s => s.IsDeleted == false).FirstOrDefault(s => s.Id == request.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Somthing went wrong", ex);
            }
        }
    }
}
