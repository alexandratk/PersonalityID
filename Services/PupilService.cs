using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeletePupil(int PupilId)
        {
            var deletingPupilDescription =
             await database.Pupil.FirstOrDefaultAsync(p => p.Id == PupilId);

            if (deletingPupilDescription is null)
                throw new System.Exception("No proper Parent found");

            database.Pupil.Remove(deletingPupilDescription);
            await database.SaveChangesAsync();

        }
    }
}