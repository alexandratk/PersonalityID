using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class Device
    {
        public Device()
        {
            MovingPupils = new List<MovingPupil>();
            MovingTeachers = new List<MovingTeacher>();
            MovingEmployees = new List<MovingEmployee>();
        }
        public int Id { get; set; }
        public EducationalInstitution EducationalInstitution { get; set; }
        public IList<MovingPupil> MovingPupils { get; set; }
        public IList<MovingTeacher> MovingTeachers { get; set; }
        public IList<MovingEmployee> MovingEmployees { get; set; }
    }
}