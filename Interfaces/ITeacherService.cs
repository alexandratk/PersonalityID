using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface ITeacherService
    {
         Task<Teacher> AddTeacher(Teacher newTeacher);
         Task DeleteTeacher(int teacherId);
    }
}