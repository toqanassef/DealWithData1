using Application.Country.Model;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Country.Query
{
    public class GetAllCountryQuery : IRequest<List<CountryDto>>
    {
        public int? PageNum { get; set; }
        public class Handler : IRequestHandler<GetAllCountryQuery, List<CountryDto>>
        {
            private readonly IEnozomDBContext _context;
            private readonly ILogger<Handler> _logger;
            private readonly IMapper _mapper;
            public Handler(IEnozomDBContext context, ILogger<Handler> logger,IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }

            public async Task<List<CountryDto>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    int PageSize = 50;
                    int skip = request.PageNum == null ? 0 : (int)request.PageNum * PageSize;
                    var Countries = await _context.Countries.Skip(skip).Take(PageSize).ToListAsync();
                    var CountriesDto = _mapper.Map<List<CountryDto>>(Countries);
                    return CountriesDto;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error in GetAllCountryQuery : {e}");
                    throw;
                }
            }
        }
    }
}
