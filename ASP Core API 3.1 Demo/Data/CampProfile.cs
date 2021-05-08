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
                .ReverseMap()
                // To Ignore Mapping In the Reverse Map
                .ForMember(t => t.Camp, opt => opt.Ignore())
                .ForMember(t => t.Speaker, opt => opt.Ignore());

            CreateMap<Speaker, SpeakerModel>()
                .ReverseMap();

        }
    }
}
