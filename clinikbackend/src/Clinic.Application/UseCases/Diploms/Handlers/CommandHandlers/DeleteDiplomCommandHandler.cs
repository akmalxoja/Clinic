using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Diploms.Commands;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Diploms.Handlers.CommandHandlers
{
    public class DeleteDiplomCommandHandler : IRequestHandler<DeleteDiplomCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public DeleteDiplomCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteDiplomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var diplom = await _clinincDbContext.Diploms
                    .Where(x => x.IsDeleted == false)
                        .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (diplom == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not found",
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }

                diplom.IsDeleted = true;

                _clinincDbContext.Diploms.Update(diplom);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Successfully Deleted",
                    IsSuccess = true,
                    StatusCode = 200,
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
