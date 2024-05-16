using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Doctors.Queries;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.UseCases.Doctors.Handlers.QueryHandlers
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public GetDoctorByIdQueryHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _clinincDbContext.Doctors.Where(d => d.IsDeleted == false).FirstOrDefaultAsync(d => d.Id == request.Id) ?? throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex);
            }
        }
    }
}
