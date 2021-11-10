using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class PupilProfile : Profile
    {
        public PupilProfile()
        {
            CreateMap<PupilDto, Pupil>().ForMember(dto => dto.Id, memberOptions => memberOptions.Ignore());
        }
    }
}