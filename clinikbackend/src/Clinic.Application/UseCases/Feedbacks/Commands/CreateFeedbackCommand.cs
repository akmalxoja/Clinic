using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Feedbacks.Commands
{
    public class CreateFeedbackCommand : IRequest<ResponseModel>
    {
        public IFormFile? Video { get; set; }
        public string Description { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
    }
}
