using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Diploms.Quries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.UseCases.Diploms.Handlers.QueryHandlers
{
    public class GetAllDiplomsQueryHandler : IRequestHandler<GetAllDiplomsQuery, IEnumerable<Diplom>>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetAllDiplomsQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<IEnumerable<Diplom>> Handle(GetAllDiplomsQuery request, CancellationToken cancellationToken)
        {
            return await _clinincDbContext.Diploms
                .Skip(request.PageIndex - 1)
                    .Take(request.Size)
                        .Where(x => x.IsDeleted == false)
                            .ToListAsync();
        }
    }
}
