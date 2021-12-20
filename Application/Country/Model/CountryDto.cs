using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Model
{
    public class CountryDto : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Country, CountryDto>();
        }
    }
}
