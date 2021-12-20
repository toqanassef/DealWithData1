using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Holiday.Command
{
    public class AddHolidayToCountry : IRequest<int>
    {
        public int CountryId { get; set; }
        public int HolidayId { get; set; }
        public class Handler : IRequestHandler<AddHolidayToCountry, int>
        {
            private readonly IEnozomDBContext _context;
            private readonly ILogger<Handler> _logger;
            public Handler(IEnozomDBContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<int> Handle(AddHolidayToCountry request, CancellationToken cancellationToken)
            {
                try
                {
                    var countryHoliday = new CountryHolidays
                    {
                        CountryId = request.CountryId,
                        HolidayId = request.HolidayId
                    };
                    _context.countryHolidays.Add(countryHoliday);
                    await _context.SaveChangesAsync(cancellationToken);

                    return countryHoliday.Id;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error in AddHolidayToCountry : {e}");
                    throw;
                }
            }
        }
    }
}
