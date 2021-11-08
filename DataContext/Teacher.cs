using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Teacher
    {
        public Teacher()
        {
            MovingTeachers = new List<MovingTeacher>();
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public EducationalInstitution EducationalInstitution { get; set; }
        public IList<MovingTeacher> MovingTeachers { get; set; }
    }
}