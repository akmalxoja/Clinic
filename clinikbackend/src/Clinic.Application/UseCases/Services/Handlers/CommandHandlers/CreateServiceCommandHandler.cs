using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Services.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;

namespace Clinic.Application.UseCases.Services.Handlers.CommandHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public CreateServiceCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            Service service = new Service()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ServiceTypeId = request.ServiceTypeId,
            };

            try
            {
                await _clinincDbContext.Services.AddAsync(service);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = ex.Message,
                };
            }

            return new ResponseModel()
            {
                IsSuccess = true,
                StatusCode = 201,
                Message = "Succesfully Created"
            };
        }
    }
}
