using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Doctors.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Clinic.Application.UseCases.Doctors.Handlers.CommandHandlers
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, ResponseModel>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IClinincDbContext _clinincDbContext;

        public CreateDoctorCommandHandler(IClinincDbContext clinincDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _clinincDbContext = clinincDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
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
                        filePath = Path.Combine(_webHostEnvironment.WebRootPath, "DoctorPh", fileName);
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

                var doctor = new Doctor()
                {
                    Name = request.Name,
                    Address = request.Address,
                    StartWork = request.StartWork,
                    TUsername = request.TUsername,
                    ServiceTypeId = request.ServiceTypeId,
                    SpecialistId = request.SpecialistId,
                    PicturePath = filePath,
                    IsDeleted = false
                };

                await _clinincDbContext.Doctors.AddAsync(doctor);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Message = "Saved"
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
