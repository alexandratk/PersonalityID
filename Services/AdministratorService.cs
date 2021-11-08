using System.Threading.Tasks;
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
    }
}