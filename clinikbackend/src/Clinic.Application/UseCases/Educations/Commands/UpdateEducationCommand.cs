using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.ResponseCaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Educations.Commands
{
    public class UpdateEducationCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Degree { get; set; }
    }
}
