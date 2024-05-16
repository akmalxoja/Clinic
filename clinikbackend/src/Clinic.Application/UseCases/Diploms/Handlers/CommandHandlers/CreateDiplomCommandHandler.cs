using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Diploms.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Diploms.Handlers.CommandHandlers
{
    public class CreateDiplomCommandHandler : IRequestHandler<CreateDiplomCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateDiplomCommandHandler(IClinincDbContext clinincDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _clinincDbContext = clinincDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateDiplomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string fileName = "";
                string filePath = "";

                if (request.Picture is not null)
                {
                    var file = request.Picture;

                    try
                    {
                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        filePath = Path.Combine(_webHostEnvironment.WebRootPath, "DiplomPics", fileName);
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

                var diplom = new Diplom()
                {
                    PicturePath = filePath,
                    LitsenzyaId = request.LitsenzyaId,
                    DoctorId = request.DoctorId
                };

                await _clinincDbContext.Diploms.AddAsync(diplom);
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
