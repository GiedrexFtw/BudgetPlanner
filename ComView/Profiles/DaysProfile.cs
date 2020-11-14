using AutoMapper;
using ComView.Dto;
using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Profiles
{
    public class DaysProfile:Profile
    {
        public DaysProfile()
        {
            CreateMap<Day, DayReadDto>();
            CreateMap<DayCreateDto, Day>();
            CreateMap<DayUpdateDto, Day>();
            CreateMap<Day, DayUpdateDto>();
        }
    }
}
