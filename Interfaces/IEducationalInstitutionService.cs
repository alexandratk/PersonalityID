using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Itrefaces
{
    public interface IEducationalInstitutionService
    {
        Task<EducationalInstitution> AddEducationalInstitution(EducationalInstitution newEducationalInstitution);
        Task<EducationalInstitution> UpdateEducationalInstitution(EducationalInstitutionDto newEducationalInstitution, int eduId);
        Task DeleteEducationalInstitution(int educationalInstitutionId);
    }
}