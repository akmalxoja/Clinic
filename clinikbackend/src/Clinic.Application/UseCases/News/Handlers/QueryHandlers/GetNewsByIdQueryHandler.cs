using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.News.Queries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.UseCases.News.Handlers.QueryHandlers
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, New>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetNewsByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<New> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _clinincDbContext.News.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(n => n.Id == request.Id) ?? throw new Exception("Not found");
            }
            catch (Exception ex)
            {
                throw new Exception("Somethig went wrong");
            }
        }
    }
}
