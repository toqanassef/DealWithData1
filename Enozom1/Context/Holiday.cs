using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enozom1.Context
{
    public class Holiday
    {
        public Holiday()
        {
            CountryHolidays = new HashSet<CountryHolidays>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<CountryHolidays> CountryHolidays { get; set; }
    }
}
