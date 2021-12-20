using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Holiday.Query
{
    public class GetIsCountreHolidayExist : IRequest<bool>
    {
        public int CountryId { get; set; }
        public int HolidayId { get; set; }
        public class Handler : IRequestHandler<GetIsCountreHolidayExist, bool>
        {
            private readonly IEnozomDBContext _context;
            private readonly ILogger<Handler> _logger;
            public Handler(IEnozomDBContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<bool> Handle(GetIsCountreHolidayExist request, CancellationToken cancellationToken)
            {
                try
                {
                    var IsExist = await _context.countryHolidays.Where
                    (a => a.CountryId == request.CountryId && a.HolidayId == request.HolidayId)
                    .AnyAsync();
                    return IsExist;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error in GetIsCountreHolidayExist : {e}");
                    throw;
                }
            }
        }
    }
}
