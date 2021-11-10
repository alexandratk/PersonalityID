using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteTeacher(int TeacherId)
        {
            var deletingTeacherDescription =
             await database.Teacher.FirstOrDefaultAsync(p => p.Id == TeacherId);

            if (deletingTeacherDescription is null)
                throw new System.Exception("No proper Parent found");

            database.Teacher.Remove(deletingTeacherDescription);
            await database.SaveChangesAsync();

        }
    }
}