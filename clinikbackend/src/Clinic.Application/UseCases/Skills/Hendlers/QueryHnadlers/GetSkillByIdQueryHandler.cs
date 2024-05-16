using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Diploms.Quries;
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
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, Skill>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetSkillByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<Skill> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _clinincDbContext.Skills
                .Where(x => x.IsDeleted == false)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);


            if (skill == null)
            {
                throw new Exception("Not found");
            }

            return skill;

        }
    }
}
