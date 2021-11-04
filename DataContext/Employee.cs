using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class Employee
    {
        public Employee()
        {
            MovingEmployees = new List<MovingEmployee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public EducationalInstitution EducationalInstitution { get; set; }
        public IList<MovingEmployee> MovingEmployees { get; set; }
    }
}