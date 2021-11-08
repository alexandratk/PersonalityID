using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class MovingEmployeeDto
    {
        public DateTime Time { get; set; }
        public int DeviceId { get; set; }
        public int EmployeeId { get; set; }
    }
}