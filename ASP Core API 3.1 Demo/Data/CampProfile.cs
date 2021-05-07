using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_Core_API_3._1_Demo.Data.Entities;
using ASP_Core_API_3._1_Demo.Model;
using ASP_Core_API_3._1_Demo.Models;
using AutoMapper;

namespace ASP_Core_API_3._1_Demo.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            this.CreateMap<Camp, CampModel>()
                .ForMember(m => m.VenueName, o => o.MapFrom(v => v.Location.VenueName))
                .ReverseMap();

            CreateMap<Talk, TalkModel>()
                .ReverseMap();

            CreateMap<Speaker, SpeakerModel>()
                .ReverseMap();

        }
    }
}
