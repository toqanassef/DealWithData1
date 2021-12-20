using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class EnozomDBContext : DbContext , IEnozomDBContext
    {
        public EnozomDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        public DbSet<CountryHolidays> countryHolidays { get; set; }
    }
}
