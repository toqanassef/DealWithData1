using Application.Holiday.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Holiday.Query
{
    public class GetAllHolidayByCountryId : IRequest<List<CountryHolidayDto>>
    {
        public int CountryId { get; set; }
        public class Handler : IRequestHandler<GetAllHolidayByCountryId, List<CountryHolidayDto>>
        {
            private readonly IEnozomDBContext _context;
            private readonly ILogger<Handler> _logger;
            public Handler(IEnozomDBContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<List<CountryHolidayDto>> Handle(GetAllHolidayByCountryId request, CancellationToken cancellationToken)
            {
                try
                {
                    var Holidays = await _context.countryHolidays.Include(a => a.Holiday)
                        .Where(a => a.CountryId == request.CountryId)
                        .Select(a => new CountryHolidayDto 
                        {
                            Id = a.Id, HolidayId = a.HolidayId, HolidayName = a.Holiday.Name
                        }).ToListAsync();
                    return Holidays;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error in GetAllHolidayByCountryId : {e}");
                    throw;
                }
            }
        }
    }
}
