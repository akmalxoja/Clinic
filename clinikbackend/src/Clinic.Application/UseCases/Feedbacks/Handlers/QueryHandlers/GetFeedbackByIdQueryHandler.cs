using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Feedbacks.Queries;
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
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, Feedback>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetFeedbackByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<Feedback> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _clinincDbContext.Feedbacks
                .Where(x => x.IsDeleted == false)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);


            return feedback ?? throw new Exception("Not found");
        }
    }
}
