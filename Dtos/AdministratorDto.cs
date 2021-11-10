using PersonalityID.Dtos;
using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class AdministratorDto: UserRegisterDto
    {
        public int EducationalInstitutionId { get; set; }
    }
}