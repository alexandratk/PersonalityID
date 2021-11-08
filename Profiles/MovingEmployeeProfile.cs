using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class MovingEmployeeProfile : Profile
    {
        public MovingEmployeeProfile()
        {
            CreateMap<MovingEmployeeDto, MovingEmployee>();
        }
    }
}