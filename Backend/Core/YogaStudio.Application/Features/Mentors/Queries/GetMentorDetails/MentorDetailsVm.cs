using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Mentors.Queries.GetMentorDetails
{
    public class MentorDetailsVm : IMapWith<Mentor>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<YogaClass> Classes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mentor, MentorDetailsVm>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dst => dst.Classes, opt => opt.MapFrom(src => src.Classes));
        }
    }
}
