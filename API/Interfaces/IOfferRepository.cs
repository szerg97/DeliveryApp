﻿using API.DTOs;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IOfferRepository
    {
        void Update(Offer offer);
        void AddOffer(Offer offer);
        void DeleteOffer(Offer offer);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Offer>> GetOffersAsync();
        Task<IEnumerable<Offer>> GetOffersRunningAsync();
        Task<IEnumerable<Offer>> GetOffersCompleteAsync();
        Task<IEnumerable<Offer>> GetOffersByCreatorIdAsync(string id);
        Task<Offer> GetOfferByIdAsync(string id);
    }
}
