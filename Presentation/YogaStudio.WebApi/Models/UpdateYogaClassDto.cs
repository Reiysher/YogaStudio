using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Application.Features.YogaClasses.Commands.UpdateYogaClass;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;

namespace YogaStudio.WebApi.Models
{

    public class UpdateYogaClassDto : IMapWith<UpdateYogaClassCommand>
    {
        public Guid Id { get; set; }
        public Guid MentorId { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinClients { get; set; }
        public int MaxClients { get; set; }
        public YogaClassType Type { get; set; }
        public YogaClassStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateYogaClassDto, UpdateYogaClassCommand>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.MentorId, opt => opt.MapFrom(src => src.MentorId))
                .ForMember(dst => dst.Subscriptions, opt => opt.MapFrom(src => src.Subscriptions))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.MinClients, opt => opt.MapFrom(src => src.MinClients))
                .ForMember(dst => dst.MaxClients, opt => opt.MapFrom(src => src.MaxClients))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
