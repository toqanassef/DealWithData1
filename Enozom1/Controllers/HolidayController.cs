using Enozom1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enozom1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidayController : Controller
    {
        private readonly EnozomDBContext _context;

        public HolidayController(EnozomDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<CountryHolidayDto> Get(int CountryId)
        {
            var Holidays = _context.countryHolidays.Include(a => a.Holiday)
                .Where(a => a.CountryId == CountryId)
                .Select(a => new CountryHolidayDto { Id = a.Id, HolidayId = a.HolidayId, HolidayName = a.Holiday.Name } )
                .ToList();
            return Holidays;
        }
    }
}
