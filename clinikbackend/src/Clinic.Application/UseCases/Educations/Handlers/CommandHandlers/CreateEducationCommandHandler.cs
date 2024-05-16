using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Educations.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Educations.Handlers.CommandHandlers
{
    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public CreateEducationCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var edu = new Education()
                {
                    Name = request.Name,
                    Degree = request.Degree,
                    StartYear = request.StartYear,
                    EndYear = request.EndYear,
                    IsDeleted = false
                };

                await _clinincDbContext.Educations.AddAsync(edu);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Message = "Successfully created"
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
