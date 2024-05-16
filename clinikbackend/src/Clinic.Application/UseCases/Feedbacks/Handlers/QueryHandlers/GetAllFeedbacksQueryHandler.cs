using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Feedbacks.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Feedbacks.Handlers.QueryHandlers
{
    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, IEnumerable<Feedback>>
    {
        private readonly IClinincDbContext _clinicDbContext;

        public GetAllFeedbacksQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinicDbContext = clinincDbContext;
        }

        public async Task<IEnumerable<Feedback>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
        {
            return await _clinicDbContext.Feedbacks
                    .Skip(request.PageIndex)
                        .Take(request.Size)
                            .Where(x => x.IsDeleted == false)
                                .ToListAsync(cancellationToken);
        }
    }
}
