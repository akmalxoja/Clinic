using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Educations.Commands;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Educations.Handlers.CommandHandlers
{
    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public UpdateEducationCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
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

                edu.StartYear = request.StartYear;
                edu.EndYear = request.EndYear;
                edu.Degree = request.Degree;
                edu.Name = request.Name;

                _clinincDbContext.Educations.Update(edu);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Successfully create"
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
