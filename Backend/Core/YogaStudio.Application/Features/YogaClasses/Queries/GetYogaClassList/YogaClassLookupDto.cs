using AutoMapper;
using System;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassList
{
    public class YogaClassLookupDto : IMapWith<YogaClass>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        // TODO: Add more fields
        public void Mapping(Profile profile)
        {
            profile.CreateMap<YogaClass, YogaClassLookupDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title));
        }
    }
}
