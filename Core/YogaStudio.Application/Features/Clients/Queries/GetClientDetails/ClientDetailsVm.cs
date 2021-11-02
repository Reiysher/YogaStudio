using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Clients.Queries.GetClientDetails
{
    public class ClientDetailsVm : IMapWith<Client>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientDetailsVm>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dst => dst.Subscriptions, opt => opt.MapFrom(src => src.Subscriptions));
        }
    }
}
