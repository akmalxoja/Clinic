using Clinic.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Results.Commands
{
    public class DeleteResultCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
    
}
