using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using API.SignalR;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProspectController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<OfferHub> _hub;
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly ICompanyRepository _companyRepository;

        public ProspectController(ApplicationDbContext context,
            IHubContext<OfferHub> hub,
            IMapper mapper,
            IOfferRepository offerRepository,
            ICompanyRepository companyRepository)
        {
            _context = context;
            _hub = hub;
            _mapper = mapper;
            _offerRepository = offerRepository;
            _companyRepository = companyRepository;
        }

        [Authorize]
        [HttpPost("add-prospect")]
        public async Task<ActionResult<ProspectDto>> AddProspect(ProspectDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Prospect does not exist.");
            }

            Company company = new Company()
            {
                CompanyId = Guid.NewGuid().ToString(),
                CompanyName = dto.CompanyName,
                CompanyCountry = dto.CompanyCountry,
                CompanyZip = dto.CompanyZip,
                Registered = DateTime.Now,
                NumberOfEmployees = dto.NumberOfEmployees,
                CreatorId = dto.CreatorId
            };

            Offer offer = new Offer()
            {
                OfferId = Guid.NewGuid().ToString(),
                Registered = DateTime.Now,
                FromCity = dto.FromCity,
                FromCountry = dto.FromCountry,
                FromZip = dto.FromZip,
                ToCity = dto.ToCity,
                ToCountry = dto.ToCountry,
                ToZip = dto.ToZip,
                Text = dto.Text,
                Solution = dto.Solution,
                Company = company,
                CreatorId = dto.CreatorId
            };

            _companyRepository.AddCompany(company);
            await _companyRepository.SaveAllAsync();

            _offerRepository.AddOffer(offer);
            await _offerRepository.SaveAllAsync();

            var offerDto = _mapper.Map<OfferDto>(offer);

            await _hub.Clients.All.SendAsync("NewOffer", offerDto);

            return Ok(dto);
        }
    }
}
