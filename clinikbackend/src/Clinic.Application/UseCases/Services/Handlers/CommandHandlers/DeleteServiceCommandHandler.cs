using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Services.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;

namespace Clinic.Application.UseCases.Services.Handlers.CommandHandlers
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, ResponseModel>
    {

        private readonly IClinincDbContext _clinincDbContext;
        public DeleteServiceCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var services = _clinincDbContext.Services.Where(s => s.IsDeleted == false).FirstOrDefault(s => s.Id == request.Id);

            if (services == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Can not found"
                };
            }
            try
            {
                services.IsDeleted = true;
                _clinincDbContext.Services.Update(services);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Deleted"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = ex.Message
                };
            }
        }
    }
}
