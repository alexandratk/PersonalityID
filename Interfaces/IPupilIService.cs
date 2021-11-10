using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IPupilService
    {
         Task<Pupil> AddPupil(Pupil newPupil);
         Task DeletePupil(int pupilId);
    }
}