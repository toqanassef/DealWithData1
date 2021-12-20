using Enozom1.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
