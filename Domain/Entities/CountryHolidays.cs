using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CountryHolidays
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int HolidayId { get; set; }
        public Country Country { get; set; }
        public Holiday Holiday { get; set; }
    }
}
