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
    public class UpdateHoliday : IRequest<bool>
    {
        public int HolidayId { get; set; }
        public string HolidayName { get; set; }
        public class Handler : IRequestHandler<UpdateHoliday, bool>
        {
            private readonly IEnozomDBContext _context;
            private readonly ILogger<Handler> _logger;
            public Handler(IEnozomDBContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<bool> Handle(UpdateHoliday request, CancellationToken cancellationToken)
            {
                try
                {
                    var OldHoliday = _context.Holiday.Where
                    (a => a.Id == request.HolidayId)
                    .FirstOrDefault();
                    if (OldHoliday == null)
                        return false;

                    OldHoliday.Name = request.HolidayName;
                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error in UpdateHoliday : {e}");
                    throw;
                }
            }
        }
    }
}
