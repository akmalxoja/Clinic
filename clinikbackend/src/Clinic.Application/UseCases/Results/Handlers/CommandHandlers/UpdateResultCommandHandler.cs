using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Diploms.Commands;
using Clinic.Application.UseCases.Results.Commands;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Results.Handlers.CommandHandlers
{
    public class UpdateResultCommandHandler : IRequestHandler<UpdateResultCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public UpdateResultCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _clinincDbContext.Results.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);
                if (result == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not found",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                result.DoctorId = request.Id;
                result.Name = request.Name;

                _clinincDbContext.Results.Update(result);
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

