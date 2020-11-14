using ComView.Dto;
using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace ComView.Profiles
{
    public class ReportProfile: Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportReadDto>();
            CreateMap<ReportCreateDto, Report>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();
        }
    }
}
