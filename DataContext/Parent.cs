using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Parent
    {
        public Parent()
        {
            PupilParents = new List<PupilParent>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public IList<PupilParent> PupilParents { get; set; }
    }
}