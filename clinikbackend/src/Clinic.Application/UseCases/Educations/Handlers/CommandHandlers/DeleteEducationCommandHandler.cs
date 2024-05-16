using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Educations.Commands;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.UseCases.Educations.Handlers.CommandHandlers
{
    public class DeleteEducationCommandHandler : IRequestHandler<DeleteEducationCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public DeleteEducationCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var edu = await _clinincDbContext.Educations.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);


                if (edu == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Message = "Not Found"
                    };
                }

                edu.IsDeleted = true;

                _clinincDbContext.Educations.Update(edu);

                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Successfully deleted"
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
