using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.News.Commands
{
    public class CreateNewsCommand:IRequest<ResponseModel>
    {
        public IFormFile? Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public Guid DoctorId { get; set; }
    }
}
