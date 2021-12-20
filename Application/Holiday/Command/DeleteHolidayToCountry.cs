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
    public class DeleteHolidayToCountry : IRequest<bool>
    {
        public int CountryId { get; set; }
        public int HolidayId { get; set; }
        public class Handler : IRequestHandler<DeleteHolidayToCountry, bool>
        {
            private readonly IEnozomDBContext _context;
            private readonly ILogger<Handler> _logger;
            public Handler(IEnozomDBContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<bool> Handle(DeleteHolidayToCountry request, CancellationToken cancellationToken)
            {
                try
                {
                    var DeleteHoliday = _context.countryHolidays.Where
                    (a => a.CountryId == request.CountryId && a.HolidayId == request.HolidayId)
                    .FirstOrDefault();
                    if (DeleteHoliday == null)
                        return false;

                    _context.countryHolidays.Remove(DeleteHoliday);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error in DeleteHolidayToCountry : {e}");
                    throw;
                }
            }
        }
    }
}
