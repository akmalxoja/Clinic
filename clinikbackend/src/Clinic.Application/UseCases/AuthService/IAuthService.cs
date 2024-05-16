using Clinic.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.AuthService
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(User user);
    }
}
