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
    public class UpdateSkillCommandHendler : IRequestHandler<UpdateSkillCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public UpdateSkillCommandHendler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle (UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var skill = await _clinincDbContext.Skills.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);

                if(skill == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not found",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                skill.Name = request.Name;

                _clinincDbContext.Skills.Update(skill);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);
                
                return new ResponseModel()
                {
                    Message = "Successfully Updated",
                    IsSuccess = true,
                    StatusCode = 200
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
