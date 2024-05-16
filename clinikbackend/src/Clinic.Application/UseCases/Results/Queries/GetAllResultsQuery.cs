using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Results.Queries
{
    public class GetAllResultsQuery:IRequest<IEnumerable<Result>>
    {
        public int PageIndex {  get; set; }
        public int Size { get; set; }
    }
}
