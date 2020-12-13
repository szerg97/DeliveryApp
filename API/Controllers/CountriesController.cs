using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CountriesController : BaseApiController
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository countryRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            var countries = await _countryRepository.GetCountriesAsync();
            var countriesToReturn = _mapper.Map<IEnumerable<CountryDto>>(countries);

            return countriesToReturn.OrderBy(x => x.CountryName);
        }
    }
}
