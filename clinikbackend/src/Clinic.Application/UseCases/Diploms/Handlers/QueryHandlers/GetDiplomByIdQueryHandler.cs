using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Diploms.Quries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Diploms.Handlers.QueryHandlers
{
    public class GetDiplomByIdQueryHandler : IRequestHandler<GetDiplomByIdQuery, Diplom>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetDiplomByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<Diplom> Handle(GetDiplomByIdQuery request, CancellationToken cancellationToken)
        {
            var diplom = await _clinincDbContext.Diploms
                .Where(x => x.IsDeleted == false)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (diplom == null)
            {
                throw new Exception("Not found");
            }

            return diplom;

        }
    }
}
