using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Diploms.Handlers.CommandHandlers;
using Clinic.Application.UseCases.Skills.Commands;
using Clinic.Application.UseCases.Specialists.Commands;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Specialists.Handlers.CommandHandlers
{
    public class UpdateSpecialistCommandHandler : IRequestHandler<UpdateSpecialistCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public UpdateSpecialistCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateSpecialistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var specialist = await _clinincDbContext.Specialists.Where(x => x.isDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (specialist == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not found",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                specialist.Name = request.Name;
                specialist.Description = request.Description;

                _clinincDbContext.Specialists.Update(specialist);
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
