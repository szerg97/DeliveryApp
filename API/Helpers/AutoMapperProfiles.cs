using API.DTOs;
using API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMapperProfiles :  Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles.FirstOrDefault().Role.Name));
            CreateMap<UserUpdateDto, AppUser>();
            CreateMap<Message, MessageDto>();
            CreateMap<Offer, OfferDto>()
                .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => src.Creator.FirstName + " " + src.Creator.LastName))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));
            CreateMap<OfferUpdateDto, Offer>();
            CreateMap<SiteDto, Site>();
            CreateMap<Site, SiteDto>();
        }
    }
}
