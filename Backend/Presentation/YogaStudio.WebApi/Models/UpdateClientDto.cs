using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Application.Features.Clients.Commands.UpdateClient;
using YogaStudio.Domain;

namespace YogaStudio.WebApi.Models
{
    public class UpdateClientDto : IMapWith<UpdateClientCommand>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateClientDto, UpdateClientCommand>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dst => dst.Subscriptions, opt => opt.MapFrom(src => src.Subscriptions));
        }
    }
}
