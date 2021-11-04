using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Application.Features.Subscriptions.Commands.CreateSubscription;
using YogaStudio.Domain.Enums;

namespace YogaStudio.WebApi.Models
{
    public class CreateSubscriptionDto : IMapWith<CreateSubscriptionCommand>
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfClasses { get; set; }
        public SubscriptionType Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSubscriptionDto, CreateSubscriptionCommand>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dst => dst.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dst => dst.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dst => dst.NumberOfClasses, opt => opt.MapFrom(src => src.NumberOfClasses))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
        }
    }
}
