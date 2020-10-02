using AutoMapper;
using ComView.Dto;
using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Profiles
{
    public class PaymentProfile: Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentReadDto>();
        }
    }
}
