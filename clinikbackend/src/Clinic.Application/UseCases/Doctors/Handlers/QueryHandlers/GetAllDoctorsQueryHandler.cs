using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Doctors.Queries;
using Clinic.Domain.DTOs;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clinic.Application.UseCases.Doctors.Handlers.QueryHandlers
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<Doctor>>
    {
        private readonly IClinincDbContext _clinincDbContext;
        private readonly IDistributedCache _distributedCache;

        public GetAllDoctorsQueryHandler(IClinincDbContext clinincDbContext, IDistributedCache distributedCache)
        {
            _clinincDbContext = clinincDbContext;
            _distributedCache = distributedCache;
        }

        public async Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _distributedCache.GetStringAsync("Docs");


                if (data == null)
                {
                    var value = await _clinincDbContext.Doctors.Where(d => d.IsDeleted == false).Skip(request.PageIndex - 1).Take(request.Size).ToListAsync();

                    var option = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles,
                        // Other serialization options can be set here
                    };

                    await _distributedCache.SetStringAsync(
                        key: "Docs",
                        value: JsonSerializer.Serialize(value, option),
                        options: new DistributedCacheEntryOptions()
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
                            SlidingExpiration = TimeSpan.FromSeconds(20),
                        }
                    );

                    return value;
                }

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    // Other serialization options can be set here
                };

                return JsonSerializer.Deserialize<Doctor[]>(data, options);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went Wrong (its not my problem)", ex);
            }
        }
    }
}
