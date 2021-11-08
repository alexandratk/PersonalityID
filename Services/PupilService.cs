using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class PupilService: IPupilService
    {
        private readonly MyDataContext database;

        public PupilService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Pupil> AddPupil(Pupil newPupil)
        {
            await database.Pupil.AddAsync(newPupil);
            await database.SaveChangesAsync();

            return newPupil;
        }
    }
}