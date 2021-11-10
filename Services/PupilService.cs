using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class PupilService : IPupilService
    {
        private readonly MyDataContext database;
        private readonly IAuthHelper<Pupil, PupilDto> authHelper;
        private readonly IUpdateHelper updateHelper;

        public PupilService(MyDataContext database, 
                            IAuthHelper<Pupil, PupilDto> authHelper,
                            IUpdateHelper updateHelper)
        {
            this.database = database;
            this.authHelper = authHelper;
            this.updateHelper = updateHelper;
        }

        public async Task<Pupil> AddPupil(PupilDto newPupilDto)
        {
            var newPupil = await authHelper.AddUserToDB(newPupilDto);
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

        public async Task<Pupil> UpdatePupil(PupilDto newPupilDto, int pupilId)
        {
            var updatedPupil = await updateHelper.updateEntity<Pupil, PupilDto>(newPupilDto, pupilId);
            return updatedPupil;
        }
    }
}