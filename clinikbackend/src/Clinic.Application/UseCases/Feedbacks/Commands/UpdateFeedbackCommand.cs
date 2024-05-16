using Clinic.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Feedbacks.Commands
{
    public class UpdateFeedbackCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string? VideoPath { get; set; }
        public string Description { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
    }
}
