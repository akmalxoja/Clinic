using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Feedbacks.Queries
{
    public class GetAllFeedbacksQuery : IRequest<IEnumerable<Feedback>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; }
    }
}
