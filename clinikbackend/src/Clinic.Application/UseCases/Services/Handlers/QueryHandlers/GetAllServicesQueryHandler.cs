using Clinic.Application.Abstractions;
using Clinic.Application.UseCases.Services.Queries;
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

namespace Clinic.Application.UseCases.Services.Handlers.QueryHandlers
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, IEnumerable<Service>>
    {
        private readonly IClinincDbContext _clinincDbContext;
        private readonly IDistributedCache _distributedCache;

        public GetAllServicesQueryHandler(IClinincDbContext clinincDbContext, IDistributedCache distributedCache)
        {
            _clinincDbContext = clinincDbContext;
            _distributedCache = distributedCache;
        }

        public async Task<IEnumerable<Service>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _distributedCache.GetStringAsync("Serices");


                if (data == null)
                {
                    var value = await _clinincDbContext.Services.Where(d => d.IsDeleted == false).Skip(request.PageIndex - 1).Take(request.Size).ToListAsync();

                    var option = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    };

                    await _distributedCache.SetStringAsync(
                        key: "Serices",
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

                return JsonSerializer.Deserialize<IEnumerable<Service>>(data, options);
            }
            catch (Exception ex)
            {
                throw new Exception(message: "Somthing went wrong in Backend)", ex);
            }
        }
    }
}
