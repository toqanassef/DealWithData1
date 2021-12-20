using AutoMapper;

namespace Application.Holiday.Model
{
    public class HolidayDto :IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Holiday, HolidayDto>();
        }
    }
}
