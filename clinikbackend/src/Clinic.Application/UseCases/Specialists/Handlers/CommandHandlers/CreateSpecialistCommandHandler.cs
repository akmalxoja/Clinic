using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Specialists.Commands;
using Clinic.Domain.DTOs;
using MediatR;

namespace Clinic.Application.UseCases.Specialists.Handlers.CommandHandlers
{
    public class CreateSpecialistCommandHandler : IRequestHandler<CreateSpecialistCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinicDbContext;

        public CreateSpecialistCommandHandler(IClinincDbContext clinicDbContext)
        {
            _clinicDbContext = clinicDbContext;
        }

        public async Task<ResponseModel> Handle(CreateSpecialistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var specials = new Domain.Entities.Specialist()
                {
                    Name = request.Name,
                    Description = request.Description,
                };


                await _clinicDbContext.Specialists.AddAsync(specials);
                await _clinicDbContext.SaveChangesAsync(cancellationToken);


                return new ResponseModel()
                {
                    Message = "Create",
                    StatusCode = 201,
                    IsSuccess = true,
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






