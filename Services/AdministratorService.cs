using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class AdministratorService: IAdministratorService
    {
        private readonly MyDataContext database;

        public AdministratorService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Administrator> AddAdministrator(Administrator newAdministrator)
        {
            await database.Administrator.AddAsync(newAdministrator);
            await database.SaveChangesAsync();

            return newAdministrator;
        }

        public async Task DeleteAdministrator(int administratorId)
        {
            var deletingAdministratorDescription =
             await database.Administrator.FirstOrDefaultAsync(p => p.Id == administratorId);

            if (deletingAdministratorDescription is null)
                throw new System.Exception("No proper place found");

            database.Administrator.Remove(deletingAdministratorDescription);
            await database.SaveChangesAsync();

        }
    }
}