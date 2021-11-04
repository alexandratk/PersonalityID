using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class MovingEmployee
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Device Device { get; set; }
        public Employee Employee { get; set; }
    }
}