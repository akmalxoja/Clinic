using Clinic.Application.Abstractions;
using Clinic.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.ServiceTypes.Commands
{
    public class DeleteServiceTypeCommand : IRequest<ResponseModel>
    {
       public Guid Id { get; set; }
    }
}
