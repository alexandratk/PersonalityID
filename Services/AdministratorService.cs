using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly MyDataContext database;
        private readonly IAuthHelper<Administrator, AdministratorDto> authHelper;
        private readonly IUpdateHelper updateHelper;

        public AdministratorService(MyDataContext database,
                                    IAuthHelper<Administrator, AdministratorDto> authHelper,
                                    IUpdateHelper updateHelper)
        {
            this.database = database;
            this.authHelper = authHelper;
            this.updateHelper = updateHelper;
        }

        public async Task<Administrator> AddAdministrator(AdministratorDto newAdministratorDto)
        {
            var newAdministrator = await authHelper.AddUserToDB(newAdministratorDto);
            EducationalInstitution timeEducationalInstitution = database.EducationalInstitution.Where(c => c.Id == newAdministratorDto.EducationalInstitutionId).FirstOrDefault();
            newAdministrator.EducationalInstitution = timeEducationalInstitution;

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

        public async Task<Administrator> UpdateAdministrator(AdministratorDto newAdministrator, int adminId)
        {
            var updatedAdministrator = await updateHelper.updateEntity<Administrator, AdministratorDto>(newAdministrator, adminId);
            return updatedAdministrator;
        }
    }
}