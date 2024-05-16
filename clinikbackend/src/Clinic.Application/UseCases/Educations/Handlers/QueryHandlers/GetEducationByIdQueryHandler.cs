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
    public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, Education>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetEducationByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<Education> Handle(GetEducationByIdQuery request, CancellationToken cancellationToken)
        {
            var edu = await _clinincDbContext.Educations.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (edu == null)
                throw new Exception();

            return edu;
        }
    }
}
