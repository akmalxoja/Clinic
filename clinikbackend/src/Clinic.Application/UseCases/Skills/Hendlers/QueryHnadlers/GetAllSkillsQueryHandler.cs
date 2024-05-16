using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Skills.Quries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Skills.Hendlers.QueryHnadlers
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, IEnumerable<Skill>>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetAllSkillsQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<IEnumerable<Skill>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _clinincDbContext.Skills
                .Where(x => x.IsDeleted == false)
                .Skip(request.PageIndex-1)
                .Take(request.Size)
                .ToListAsync();
        }
    }
}
