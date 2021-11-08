using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class TeacherService: ITeacherService
    {
        private readonly MyDataContext database;

        public TeacherService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Teacher> AddTeacher(Teacher newTeacher)
        {
            await database.Teacher.AddAsync(newTeacher);
            await database.SaveChangesAsync();

            return newTeacher;
        }
    }
}