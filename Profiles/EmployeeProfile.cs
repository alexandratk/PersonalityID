using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>().ForMember(dto => dto.Id, memberOptions => memberOptions.Ignore());
        }
    }
}