using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly MyDataContext database;
        private readonly IAuthHelper<Teacher, TeacherDto> authHelper;
        private readonly IUpdateHelper updateHelper;

        public TeacherService(MyDataContext database,
                               IAuthHelper<Teacher, TeacherDto> authHelper,
                               IUpdateHelper updateHelper)
        {
            this.database = database;
            this.authHelper = authHelper;
            this.updateHelper = updateHelper;
        }

        public async Task<Teacher> AddTeacher(TeacherDto newTeacherDto)
        {
            var newTeacher = await authHelper.AddUserToDB(newTeacherDto);

            EducationalInstitution timeEducationalInstitution = database.EducationalInstitution
                .Where(c => c.Id == newTeacherDto.EducationalInstitutionId).FirstOrDefault();

            newTeacher.EducationalInstitution = timeEducationalInstitution;
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

        public async Task<Teacher> UpdateTeacher(TeacherDto newTeacher, int teacherId)
        {
            var updatedTeacher = await updateHelper.updateEntity<Teacher, TeacherDto>(newTeacher, teacherId);
            return updatedTeacher;
        }
    }
}