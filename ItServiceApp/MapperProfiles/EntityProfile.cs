using AutoMapper;
using ItServiceApp.Models.Entities;
using ItServiceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.MapperProfiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<SubscriptionType, SubscriptionTypeViewModel>().ReverseMap();
        }
        
    }
}
