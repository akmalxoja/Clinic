using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Diploms.Commands;
using Clinic.Application.UseCases.Results.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Results.Handlers.CommandHandlers
{
    public class CreateResultCommandHandler: IRequestHandler<CreateResultCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateResultCommandHandler(IClinincDbContext clinincDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _clinincDbContext = clinincDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string fileName = "";
                string fileName2 = "";
                string filePath = "";
                string filePath2 = "";

                if (request.PhotoBefore  is not null && request.PhotoAfter is not null)
                {
                    var file = request.PhotoBefore;
                    var file2 = request.PhotoAfter;


                    try
                    {
                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        filePath = Path.Combine(_webHostEnvironment.WebRootPath, "BeforPic", fileName);
                        filePath2 = Path.Combine(_webHostEnvironment.WebRootPath, "AfterPic", fileName2);


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            await file2.CopyToAsync(stream);
                        }

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

                var result = new Result()
                {
                    Name = request.Name,
                    PhotoBefore = filePath,
                    PhotoAfter = filePath2,
                    DoctorId = request.DoctorId
                    
                   
                };

                await _clinincDbContext.Results.AddAsync(result);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

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


