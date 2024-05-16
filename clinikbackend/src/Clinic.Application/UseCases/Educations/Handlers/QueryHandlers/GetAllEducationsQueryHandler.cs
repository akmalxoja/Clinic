using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Educations.Queries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Educations.Handlers.QueryHandlers
{
    public class GetAllEducationsQueryHandler : IRequestHandler<GetAllEducationsQuery, IEnumerable<Education>>
    {
        private readonly IClinincDbContext _clinicDbContext;

        public GetAllEducationsQueryHandler(IClinincDbContext clinicDbContext)
        {
            _clinicDbContext = clinicDbContext;
        }

        public async Task<IEnumerable<Education>> Handle(GetAllEducationsQuery request, CancellationToken cancellationToken)
        {
            return await _clinicDbContext.Educations.Where(x => x.IsDeleted == false).Skip(request.PageIndex-1).Take(request.Size).ToListAsync();
        }
    }
}
