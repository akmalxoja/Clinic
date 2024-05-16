using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Services.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Specialists.Handlers.CommandHandlers
{
    public class DeleteSpecialistCommandHandler : IRequestHandler<DeleteServiceCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinicDbContext;

        public DeleteSpecialistCommandHandler(IClinincDbContext clinicDbContext)
        {
            _clinicDbContext = clinicDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var specialist = await _clinicDbContext.Specialists
                    .Where(x => x.isDeleted == false)
                        .FirstOrDefaultAsync(x => x.Id == request.Id);
                
                if (specialist == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not found",
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }
                specialist.isDeleted = true;

                _clinicDbContext.Specialists.Update(specialist);

                await _clinicDbContext.SaveChangesAsync(cancellationToken);

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
