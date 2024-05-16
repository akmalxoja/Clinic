using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.News.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.News.Handlers.CommandHandlers
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public DeleteNewsCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var newModel = await _clinincDbContext.News.Where(n => n.IsDeleted == false).FirstOrDefaultAsync(n => n.Id == request.Id);
            if (newModel == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "Not Found",
                };
            }
            try
            {
                newModel.IsDeleted = true;
                _clinincDbContext.News.Update(newModel);

                return new ResponseModel()
                {
                    IsSuccess = true,
                    StatusCode = 203,
                    Message = "Succesfully Deleted",
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
