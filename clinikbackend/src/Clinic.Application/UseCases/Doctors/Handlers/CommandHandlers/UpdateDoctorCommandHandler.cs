using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Doctors.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.UseCases.Doctors.Handlers.CommandHandlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public UpdateDoctorCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }
        public async Task<ResponseModel> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _clinincDbContext.Doctors.Where(d => d.IsDeleted == false).FirstOrDefaultAsync(d => d.Id == request.Id);
            if (doctor == null)
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
                doctor.Name = request.Name;
                doctor.Address = request.Address;
                doctor.StartWork = request.StartWork;
                doctor.TUsername = request.TUsername;
                doctor.PicturePath = request.Picture.FileName;
                doctor.SpecialistId = request.SpecialistId;
                doctor.ServiceTypeId = request.ServiceTypeId;

                _clinincDbContext.Doctors.Update(doctor);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);
                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 202,
                    Message = "Successfully Updated"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
        }
    }
}

