using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Pupil : User
    {
        public Pupil()
        {
            Groups = new List<Group>();
            MovingPupils = new List<MovingPupil>();
            PupilParents = new List<PupilParent>();
        }
        public IList<Group> Groups { get; set; }
        public IList<MovingPupil> MovingPupils { get; set; }
        public IList<PupilParent> PupilParents { get; set; }
    }
}