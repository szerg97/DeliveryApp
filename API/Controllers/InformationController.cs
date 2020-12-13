using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class InformationController : BaseApiController
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICountryRepository _countryRepository;

        public InformationController(ICompanyRepository companyRepository,
            IOfferRepository offerRepository,
            IUserRepository userRepository,
            ICountryRepository countryRepository)
        {
            _companyRepository = companyRepository;
            _offerRepository = offerRepository;
            _userRepository = userRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet("companies")]
        public async Task<ActionResult<int>> GetCompaniesCount()
        {
            var companies = await _companyRepository.GetCompaniesAsync();

            return Ok(companies.Count());
        }

        [HttpGet("users")]
        public async Task<ActionResult<int>> GetUsersCount()
        {
            var users = await _userRepository.GetUsersAsync();

            return Ok(users.Count());
        }

        [HttpGet("countries")]
        public async Task<ActionResult<int>> GetCountriesCount()
        {
            var countries = await _countryRepository.GetCountriesAsync();

            return Ok(countries.Count());
        }

        [HttpGet("offers")]
        public async Task<ActionResult<int>> GetOffersCount()
        {
            var offers = await _offerRepository.GetOffersAsync();

            return Ok(offers.Count());
        }

        [HttpGet("offers-running")]
        public async Task<ActionResult<int>> GetOffersRunningCount()
        {
            var offers = await _offerRepository.GetOffersRunningAsync();

            return Ok(offers.Count());
        }
        [HttpGet("offers-complete")]
        public async Task<ActionResult<int>> GetOffersCompleteCount()
        {
            var offers = await _offerRepository.GetOffersCompleteAsync();

            return Ok(offers.Count());
        }
    }
}
