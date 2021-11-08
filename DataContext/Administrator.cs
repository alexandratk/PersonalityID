using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public EducationalInstitution EducationalInstitution { get; set; }
    }
}