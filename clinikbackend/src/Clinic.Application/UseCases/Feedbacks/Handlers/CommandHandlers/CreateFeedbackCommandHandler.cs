using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Feedbacks.Commands;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Feedbacks.Handlers.CommandHandlers
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, ResponseModel>
    {
        private readonly IClinincDbContext _clinicDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateFeedbackCommandHandler(IClinincDbContext clinicDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _clinicDbContext = clinicDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            try
            {

                string fileName = "";
                string filePath = "";

                if (request.Video is not null)
                {
                    var file = request.Video;


                    try
                    {
                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        filePath = Path.Combine(_webHostEnvironment.WebRootPath, "FeedbackVidos", fileName);
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

                var feedback = new Feedback()
                {
                    VideoPath = filePath,
                    ServiceId = request.ServiceId,
                    DoctorId = request.DoctorId,
                    Description = request.Description
                };

                await _clinicDbContext.Feedbacks.AddAsync(feedback);
                await _clinicDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Successfully",
                    IsSuccess = true,
                    StatusCode = 201
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
