using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class MovingTeacherService: IMovingTeacherService
    {
        private readonly MyDataContext database;

        public MovingTeacherService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<MovingTeacher> AddMovingTeacher(MovingTeacher newMovingTeacher)
        {
            await database.MovingTeacher.AddAsync(newMovingTeacher);
            await database.SaveChangesAsync();

            return newMovingTeacher;
        }
    }
}