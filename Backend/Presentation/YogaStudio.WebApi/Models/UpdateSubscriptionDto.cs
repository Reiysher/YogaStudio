using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Application.Features.Subscriptions.Commands.UpdateSubscription;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;

namespace YogaStudio.WebApi.Models
{
    public class UpdateSubscriptionDto : IMapWith<UpdateSubscriptionCommand>
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public IEnumerable<YogaClass> Classes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfClasses { get; set; }
        public SubscriptionType Type { get; set; }
        public SubscriptionStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSubscriptionDto, UpdateSubscriptionCommand>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dst => dst.Classes, opt => opt.MapFrom(src => src.Classes))
                .ForMember(dst => dst.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dst => dst.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dst => dst.NumberOfClasses, opt => opt.MapFrom(src => src.NumberOfClasses))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
