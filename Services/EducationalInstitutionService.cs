using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class EducationalInstitutionService: IEducationalInstitutionService
    {
        private readonly MyDataContext database;

        public EducationalInstitutionService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<EducationalInstitution> AddEducationalInstitution(EducationalInstitution newEducationalInstitution)
        {
            await database.EducationalInstitution.AddAsync(newEducationalInstitution);
            await database.SaveChangesAsync();

            return newEducationalInstitution;
        }
    }
}