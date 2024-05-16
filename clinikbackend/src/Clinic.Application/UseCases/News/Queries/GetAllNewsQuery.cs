using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.News.Queries
{
    public class GetAllNewsQuery:IRequest<IEnumerable<New>>
    {
        public int PageIndex {  get; set; }
        public int Size { get; set; }
    }
}
