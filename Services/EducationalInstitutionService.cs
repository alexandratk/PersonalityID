using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class EducationalInstitutionService : IEducationalInstitutionService
    {
        private readonly MyDataContext database;
        private readonly IUpdateHelper updateHelper;

        public EducationalInstitutionService(MyDataContext database, IUpdateHelper updateHelper)
        {
            this.updateHelper = updateHelper;
            this.database = database;
        }

        public async Task<EducationalInstitution> AddEducationalInstitution(EducationalInstitution newEducationalInstitution)
        {
            await database.EducationalInstitution.AddAsync(newEducationalInstitution);
            await database.SaveChangesAsync();

            return newEducationalInstitution;
        }

        public async Task DeleteEducationalInstitution(int EducationalInstitutionId)
        {
            var deletingEducationalInstitutionDescription =
             await database.EducationalInstitution.FirstOrDefaultAsync(p => p.Id == EducationalInstitutionId);

            if (deletingEducationalInstitutionDescription is null)
                throw new System.Exception("No proper place found");

            database.EducationalInstitution.Remove(deletingEducationalInstitutionDescription);
            await database.SaveChangesAsync();

        }

        public async Task<EducationalInstitution> UpdateEducationalInstitution(EducationalInstitutionDto newEducationalInstitution, int eduId)
        {
            var updatedEduInst = await updateHelper.updateEntity<EducationalInstitution, EducationalInstitutionDto>(newEducationalInstitution, eduId);
            return updatedEduInst;
        }
    }
}