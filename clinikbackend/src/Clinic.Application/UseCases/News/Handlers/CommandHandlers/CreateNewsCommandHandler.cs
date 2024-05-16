using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.News.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.News.Handlers.CommandHandlers
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateNewsCommandHandler(IClinincDbContext clinincDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _clinincDbContext = clinincDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {

            string fileName = "";
            string filePath = "";

            if (request.Picture is not null)
            {
                var file = request.Picture;


                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "NewPh", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
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
            New newModel = new New()
            {
                PicturePath = filePath,
                Title = request.Title,
                Description = request.Description,
                Date = request.Date,
                DoctorId = request.DoctorId,
            };

            try
            {
                await _clinincDbContext.News.AddAsync(newModel);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Message = "Successfully Created!",
                };
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
        }
    }
}
