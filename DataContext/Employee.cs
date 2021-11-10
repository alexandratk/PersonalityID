using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class Employee : User
    {
        public Employee()
        {
            MovingEmployees = new List<MovingEmployee>();
        }
        public EducationalInstitution EducationalInstitution { get; set; }
        public IList<MovingEmployee> MovingEmployees { get; set; }
    }
}