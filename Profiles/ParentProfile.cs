using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class ParentProfile : Profile
    {
        public ParentProfile()
        {
            CreateMap<ParentDto, Parent>().ForMember(dto => dto.Id, memberOptions => memberOptions.Ignore());
        }
    }
}