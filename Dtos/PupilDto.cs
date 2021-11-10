using PersonalityID.Dtos;
using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class PupilDto: UserRegisterDto
    {
        public DateTime Dateofbirth { get; set; }
    }
}