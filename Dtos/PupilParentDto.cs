using PersonalityID.Dtos;
using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class PupilParentDto: UserRegisterDto
    {
        public string Relationship { get; set; }
        public int ParentId { get; set; }
        public int PupilId { get; set; }
    }
}