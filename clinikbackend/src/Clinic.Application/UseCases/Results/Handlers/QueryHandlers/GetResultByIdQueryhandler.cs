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
    public class GetResultByIdQueryhandler:IRequestHandler<GetResultByIdQuery,Result>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetResultByIdQueryhandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<Result> Handle(GetResultByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await  _clinincDbContext.Results.Where(r => r.IsDeleted == false).FirstOrDefaultAsync(r => r.Id == request.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Somthing went wrong", ex);
            }
        }
    }
}
