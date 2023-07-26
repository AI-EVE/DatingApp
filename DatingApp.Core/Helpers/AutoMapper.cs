using AutoMapper;
using DatingApp.Core.Domain.Entities;
using DatingApp.Core.DTOs;

namespace DatingApp.Core.Helpers
{
    public class AutoMapper : Profile
{
        public AutoMapper()
        {
            CreateMap<AppUser, MemberDTO>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDTO>();
        }
    }
}