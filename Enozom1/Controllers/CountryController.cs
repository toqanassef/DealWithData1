using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Enozom1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly EnozomDBContext _context;

        public CountryController(EnozomDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Country> Get(int? PageNum)
        {
            int PageSize = 50;
            int skip = PageNum == null ? 0 : (int)PageNum * PageSize;
            var Countries = _context.Countries.ToList().Skip(skip).Take(PageSize);
            return Countries;
        }
        [HttpPost]
        public IActionResult Add(string Name)
        {
            var country = _context.Countries.Where(a => a.Name == Name).FirstOrDefault();
            if(country == null)
            {
                var newC = new Country() { Name = Name };
                _context.Countries.Add(newC);
                _context.SaveChanges();
            }
            else
            {
                //update if there more data
            }
            return Ok();
            
        }
    }
}
