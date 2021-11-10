using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Teacher : User
    {
        public Teacher()
        {
            MovingTeachers = new List<MovingTeacher>();
        }
        public EducationalInstitution EducationalInstitution { get; set; }
        public IList<MovingTeacher> MovingTeachers { get; set; }
    }
}