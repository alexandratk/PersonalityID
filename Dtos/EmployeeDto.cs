using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public int EducationalInstitutionId { get; set; }
    }
}