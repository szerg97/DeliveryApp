using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class SitesController : BaseApiController
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;

        public SitesController(ISiteRepository siteRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteDto>>> GetSites()
        {
            var sites = await _siteRepository.GetSites();
            var sitesToReturn = _mapper.Map<IEnumerable<SiteDto>>(sites);
            return Ok(sitesToReturn.OrderBy(x => x.SiteName));
        }

        [HttpGet("{siteId}")]
        public async Task<ActionResult<SiteDto>> GetSite(string siteId)
        {
            var site = await _siteRepository.GetSite(siteId);
            var siteToReturn = _mapper.Map<SiteDto>(site);
            return Ok(siteToReturn);
        }

        [HttpPost("add-site")]
        public async Task<ActionResult<SiteDto>> AddSite(SiteDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Site does not exist.");
            }

            
            var site = _mapper.Map<Site>(dto);
            site.SiteId = Guid.NewGuid().ToString();

            _siteRepository.AddSite(site);

            return Ok(dto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{siteId}")]
        public async Task<ActionResult<SiteDto>> UpdateSite( SiteDto dto)
        {
            var site = await _siteRepository.GetSite(dto.SiteId);

            _mapper.Map(dto, site);

            _siteRepository.UpdateSite(site);

            if (await _siteRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update site");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{siteId}")]
        public async Task<ActionResult> DeleteOffer(string siteId)
        {
            var site = await _siteRepository.GetSite(siteId);

            _siteRepository.DeleteSite(site);
            if (await _siteRepository.SaveAllAsync())
            {
                return Ok();
            }

            return BadRequest("Problem deleting the site");
        }
    }
}
