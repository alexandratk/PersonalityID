using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Itrefaces
{
    public interface ITeacherService
    {
         Task<Teacher> AddTeacher(TeacherDto newTeacher);
         Task<Teacher> UpdateTeacher(TeacherDto newTeacher, int teacherId);
         Task DeleteTeacher(int teacherId);
    }
}