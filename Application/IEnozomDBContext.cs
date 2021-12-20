using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public interface IEnozomDBContext
    {
        public DbSet<Domain.Entities.Country> Countries { get; set; }
        public DbSet<Domain.Entities.Holiday> Holiday { get; set; }
        public DbSet<CountryHolidays> countryHolidays { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
