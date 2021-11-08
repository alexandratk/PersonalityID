using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class MovingPupilService: IMovingPupilService
    {
        private readonly MyDataContext database;

        public MovingPupilService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<MovingPupil> AddMovingPupil(MovingPupil newMovingPupil)
        {
            await database.MovingPupil.AddAsync(newMovingPupil);
            await database.SaveChangesAsync();

            return newMovingPupil;
        }
    }
}