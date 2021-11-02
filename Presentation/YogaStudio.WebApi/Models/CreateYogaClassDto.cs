using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Application.Features.YogaClasses.Commands.CreateYogaClass;
using YogaStudio.Domain.Enums;

namespace YogaStudio.WebApi.Models
{
    public class CreateYogaClassDto : IMapWith<CreateYogaClassCommand>
    {
        public Guid MentorId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinClients { get; set; }
        public int MaxClients { get; set; }
        public YogaClassType Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateYogaClassDto, CreateYogaClassCommand>()
                .ForMember(dst => dst.MentorId, opt => opt.MapFrom(src => src.MentorId))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.MinClients, opt => opt.MapFrom(src => src.MinClients))
                .ForMember(dst => dst.MaxClients, opt => opt.MapFrom(src => src.MaxClients))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
        }
    }
}
