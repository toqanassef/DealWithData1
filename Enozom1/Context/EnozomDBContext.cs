using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enozom1.Context
{
    public class EnozomDBContext : DbContext
    {
        public EnozomDBContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Country> Countries { get; set; }
        DbSet<CountryHolidays> countryHolidays { get; set; }
    }
}
