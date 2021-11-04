using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public EducationalInstitution EducationalInstitution { get; set; }
    }
}