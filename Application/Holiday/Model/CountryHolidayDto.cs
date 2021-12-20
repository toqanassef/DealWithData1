using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Holiday.Model
{
    public class CountryHolidayDto
    {
        public int Id { get; set; }
        public int HolidayId { get; set; }

        public string HolidayName { get; set; }
    }
}
