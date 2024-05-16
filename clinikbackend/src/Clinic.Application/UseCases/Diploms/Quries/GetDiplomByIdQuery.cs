using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Diploms.Quries
{
    public class GetDiplomByIdQuery : IRequest<Diplom>
    {
        public Guid Id { get; set; }
    }
}
