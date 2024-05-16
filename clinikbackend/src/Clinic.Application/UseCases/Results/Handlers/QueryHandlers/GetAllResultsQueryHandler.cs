using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Results.Queries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Results.Handlers.QueryHandlers
{
    public class GetAllResultsQueryHandler : IRequestHandler<GetAllResultsQuery,IEnumerable<Result>>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetAllResultsQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<IEnumerable<Result>> Handle(GetAllResultsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _clinincDbContext.Results.Where(r => r.IsDeleted == false).Skip(request.PageIndex - 1).Take(request.Size).ToListAsync();
            }
            catch
            {
                throw new Exception("Something Went Wrog from AkmalXo'ja");
            }
        }

    }
}
