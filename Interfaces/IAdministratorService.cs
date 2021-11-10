using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Itrefaces
{
    public interface IAdministratorService
    {
        Task<Administrator> AddAdministrator(AdministratorDto newAdministrator);
        Task<Administrator> UpdateAdministrator(AdministratorDto newAdministrator, int adminId);
        Task DeleteAdministrator(int administratorId);
    }
}