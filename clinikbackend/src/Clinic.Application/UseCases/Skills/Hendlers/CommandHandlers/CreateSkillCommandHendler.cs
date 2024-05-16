using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Skills.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Skills.Hendlers.CommandHandlers
{
    public class CreateSkillCommandHendler : IRequestHandler<CreateSkillCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinicDbContext;

        public CreateSkillCommandHendler(IClinincDbContext clinicDbContext)
        {
            _clinicDbContext = clinicDbContext;
        }

        public async Task<ResponseModel> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var skill = new Skill()
                {

                    Name = request.Name,
                    IsDeleted = false
                    
                };

                await _clinicDbContext.Skills.AddAsync(skill);
                await _clinicDbContext.SaveChangesAsync(cancellationToken);


                return new ResponseModel()
                {
                    Message = "Moshniy",
                    StatusCode = 200,
                    IsSuccess = true,
                };

            }

            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    IsSuccess = false,
                };
            }

        }

    }
}
