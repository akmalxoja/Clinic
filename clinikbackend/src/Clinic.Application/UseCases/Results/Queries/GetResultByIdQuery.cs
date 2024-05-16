using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Results.Queries
{
    public class GetResultByIdQuery:IRequest<Result>
    {
        public Guid Id { get; set; } 
    }
}
