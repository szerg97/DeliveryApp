﻿using API.Data;
using API.DTOs;
using API.Extensions;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class OffersController : BaseApiController
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OffersController(IOfferRepository offerRepository,
            IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferDto>>> GetOffers()
        {
            var user = User;

            if (user.IsInRole("Admin"))
            {
                var offers = await _offerRepository.GetOffersAsync();

                var offersToReturn = _mapper.Map<IEnumerable<OfferDto>>(offers);

                return Ok(offersToReturn);
            }


            var offersByCreatorId = await _offerRepository.GetOffersByCreatorIdAsync(user.GetUserId());

            var offersByCreatorIdToReturn = _mapper.Map<IEnumerable<OfferDto>>(offersByCreatorId);

            return Ok(offersByCreatorIdToReturn);
        }

        [Authorize]
        [HttpGet("{offerId}")]
        public async Task<ActionResult<OfferDto>> GetOffer(string offerId)
        {           
            var offer = await _offerRepository.GetOfferByIdAsync(offerId);

            var offerToReturn = _mapper.Map<OfferDto>(offer);

            return Ok(offerToReturn);
        }
    }
}
