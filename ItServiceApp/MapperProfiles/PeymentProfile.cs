using AutoMapper;
using ItServiceApp.Models.Payment;
using Iyzipay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.MapperProfiles
{
    public class PeymentProfile : Profile
    {
        public PeymentProfile()
        {

            CreateMap<InstallmentPriceModel, InstallmentPrice>().ReverseMap();

            CreateMap<InstallmentModel, InstallmentDetail>().ReverseMap();
            CreateMap<CardModel, PaymentCard>().ReverseMap();
            


        }
    }
}
