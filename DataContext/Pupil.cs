using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Pupil
    {
        public Pupil()
        {
            Groups = new List<Group>();
            MovingPupils = new List<MovingPupil>();
            PupilParents = new List<PupilParent>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<MovingPupil> MovingPupils { get; set; }
        public IList<PupilParent> PupilParents { get; set; }
    }
}