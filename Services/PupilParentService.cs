using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class PupilParentService: IPupilParentService
    {
        private readonly MyDataContext database;

        public PupilParentService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<PupilParent> AddPupilParent(PupilParent newPupilParent)
        {
            await database.PupilParent.AddAsync(newPupilParent);
            await database.SaveChangesAsync();

            return newPupilParent;
        }
    }
}