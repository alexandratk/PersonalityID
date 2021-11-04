using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class Group
    {
        public Group()
        {
            Pupils = new List<Pupil>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public EducationalInstitution EducationalInstitution { get; set; }
        public IList<Pupil> Pupils { get; set; }
    }
}