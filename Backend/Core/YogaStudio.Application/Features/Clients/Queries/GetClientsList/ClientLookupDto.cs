using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Clients.Queries.GetClientsList
{
    public class ClientLookupDto : IMapWith<Client>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientLookupDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
