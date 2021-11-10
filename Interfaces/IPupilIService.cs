using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Itrefaces
{
    public interface IPupilService
    {
        Task<Pupil> AddPupil(PupilDto newPupilDto);
        Task<Pupil> UpdatePupil(PupilDto newPupilDto, int pupilId);
        Task DeletePupil(int pupilId);
    }
}