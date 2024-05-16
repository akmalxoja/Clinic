using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.ServiceTypes.Commands;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.ServiceTypes.Handlers.CommandHandlers
{
    public class DeleteServiceTypeCommandHandler : IRequestHandler<DeleteServiceTypeCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public DeleteServiceTypeCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteServiceTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var serviceType = await _clinincDbContext.ServiceTypes
                    .Where(x => x.IsDeleted == false)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if(serviceType == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not Found",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                serviceType.IsDeleted = true;

                _clinincDbContext.ServiceTypes.Update(serviceType);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Successfully Deleted",
                    StatusCode = 200,
                    IsSuccess = true
                };

            }catch (Exception ex)
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
