using Clinic.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Educations.Commands
{
    public class CreateEducationCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Degree { get; set; }
    }
}
