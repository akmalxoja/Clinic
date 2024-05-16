using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Skills.Commands;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Skills.Hendlers.CommandHandlers
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, ResponseModel>
    {

        private readonly IClinincDbContext _clinincDbContext;

        public DeleteSkillCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }


        public async Task<ResponseModel> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var skill = await _clinincDbContext.Skills
                    .Where(x => x.IsDeleted == false)
                        .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (skill == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not found",
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }

                skill.IsDeleted = true;

                _clinincDbContext.Skills.Update(skill);
                
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Successfully Deleted",
                    IsSuccess = true,
                    StatusCode = 200,
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}
