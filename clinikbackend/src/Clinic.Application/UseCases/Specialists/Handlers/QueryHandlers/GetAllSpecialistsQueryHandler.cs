using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Skills.Quries;
using Clinic.Application.UseCases.Specialist.Queries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Specialists.Handlers.QueryHandlers
{
    public class GetAllSpecialistsQueryHandler : IRequestHandler<GetAllSpecialistsQuery, IEnumerable<Domain.Entities.Specialist>>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetAllSpecialistsQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<IEnumerable<Domain.Entities.Specialist>> Handle(GetAllSpecialistsQuery request, CancellationToken cancellationToken)
        {
            return await _clinincDbContext.Specialists
                .Where(x => x.isDeleted == false)
                .Skip(request.PageIndex-1)
                .Take(request.Size)
                    .ToListAsync();
        }


    }
}
