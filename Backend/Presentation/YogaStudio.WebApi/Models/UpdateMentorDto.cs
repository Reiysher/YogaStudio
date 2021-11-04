using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Application.Features.Mentors.Commands.UpdateMentor;
using YogaStudio.Domain;

namespace YogaStudio.WebApi.Models
{
    public class UpdateMentorDto : IMapWith<UpdateMentorCommand>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<YogaClass> Classes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMentorDto, UpdateMentorCommand>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dst => dst.Classes, opt => opt.MapFrom(src => src.Classes));
        }
    }
}
