using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Feedbacks.Commands;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Feedbacks.Handlers.CommandHandlers
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinincDbContext;

        public DeleteFeedbackCommandHandler(IClinincDbContext clinincDbContext)
        {
            _clinincDbContext = clinincDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var feedback = await _clinincDbContext.Feedbacks.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (feedback == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = true,
                        StatusCode = 404,
                        Message = "Not found"
                    };
                }

                feedback.IsDeleted = true;
                _clinincDbContext.Feedbacks.Update(feedback);
                await _clinincDbContext.SaveChangesAsync(cancellationToken);
                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Message = "Deleted"
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
