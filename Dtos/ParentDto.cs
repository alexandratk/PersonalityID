using PersonalityID.Dtos;
using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class ParentDto: UserRegisterDto
    {
        public DateTime Dateofbirth { get; set; }
        public string Contact { get; set; }
    }
}