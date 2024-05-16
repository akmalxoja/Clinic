using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Services.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;

namespace Clinic.Application.UseCases.Services.Handlers.CommandHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public UpdateServiceCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _clinincDbContext.Services.Where(s => s.IsDeleted == false).FirstOrDefault(s => s.Id == request.Id);
            if (service == null)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Not Found"
                };
            }

            try
            {
                service.Name = request.Name;
                service.Price = request.Price;
                service.Description = request.Description;
                service.ServiceTypeId = request.ServiceTypeId;

                _clinincDbContext.Services.Update(service);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Succesfully Updated"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = ex.Message
                };
            }
        }
    }
}
