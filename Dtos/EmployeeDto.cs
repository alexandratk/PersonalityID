using PersonalityID.Dtos;
using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class EmployeeDto: UserRegisterDto
    {
        public DateTime Dateofbirth { get; set; }
        public int EducationalInstitutionId { get; set; }
    }
}