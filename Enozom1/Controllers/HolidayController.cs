﻿using Enozom1.Context;
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
        [HttpPost]
        public IActionResult Add(int CountryId ,int HolidayId )
        {
            try
            {
                var IfExist = _context.countryHolidays.Where
                    (a => a.CountryId == CountryId && a.HolidayId == HolidayId)
                    .Any();
                if (IfExist)
                {
                    return Conflict();
                }
                else
                {
                    var countryHoliday = new CountryHolidays
                    {
                        CountryId = CountryId,
                        HolidayId = HolidayId
                    };
                    _context.countryHolidays.Add(countryHoliday);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                throw;
            }
            
        }
        [HttpDelete]
        public IActionResult Delete (int CountryId, int HolidayId)
        {
            try
            {
                var DeleteHoliday = _context.countryHolidays.Where
                    (a => a.CountryId == CountryId && a.HolidayId == HolidayId)
                    .FirstOrDefault();
                if (DeleteHoliday == null)
                    return NotFound();
    
                _context.countryHolidays.Remove(DeleteHoliday);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                throw;
            }

        }
        [HttpPut]
        public IActionResult Update(int HolidayId , string HolidayName)
        {
            try
            {
                var OldHoliday = _context.Holiday.Where
                    (a => a.Id == HolidayId)
                    .FirstOrDefault();
                if (OldHoliday == null)
                    return NotFound();

                OldHoliday.Name = HolidayName;
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                throw;
            }

        }
        
    }
}
