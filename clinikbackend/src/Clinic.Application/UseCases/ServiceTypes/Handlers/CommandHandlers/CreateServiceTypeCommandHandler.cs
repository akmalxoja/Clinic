using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.ServiceTypes.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.ServiceTypes.Handlers.CommandHandlers
{
    public class CreateServiceTypeCommandHandler : IRequestHandler<CreateServiceTypeCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public CreateServiceTypeCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(CreateServiceTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var serviceType = new ServiceType()
                {
                    Name = request.Name
                };

                await _clinincDbContext.ServiceTypes.AddAsync(serviceType);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Created",
                    StatusCode = 201,
                    IsSuccess = true
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
