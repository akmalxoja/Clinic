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
    
    public class GetSpecialistByIdQueryHandler : IRequestHandler<GetSpecialistByIdQuery, Domain.Entities.Specialist>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetSpecialistByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<Domain.Entities.Specialist> Handle(GetSpecialistByIdQuery request, CancellationToken cancellationToken)
        {
            var s = await _clinincDbContext.Specialists
                .Where(x => x.isDeleted == false)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);


            if (s == null)
            {
                throw new Exception("Not found");
            }

            return s;

        }
    }
}
