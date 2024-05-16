using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.News.Queries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.UseCases.News.Handlers.QueryHandlers
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<New>>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetAllNewsQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<IEnumerable<New>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            return await _clinincDbContext.News.Where(x => x.IsDeleted == false).Skip(request.PageIndex - 1).Take(request.Size).ToListAsync();
        }
    }
}
