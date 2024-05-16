using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Doctors.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.UseCases.Doctors.Handlers.CommandHandlers
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public DeleteDoctorCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _clinincDbContext.Doctors.Where(d => d.IsDeleted == false).FirstOrDefaultAsync(d => d.Id == request.Id);
            if (doctor == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Not Found"
                };
            }
            try
            {
                doctor.IsDeleted = true;
                _clinincDbContext.Doctors.Update(doctor);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);
                return new ResponseModel()
                {
                    IsSuccess = true,
                    StatusCode = 203,
                    Message = "Successfuly Deleted!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = "Somthing Went Wrong"
                };
            }
        }
    }
}
