using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IAdministratorService
    {
         Task<Administrator> AddAdministrator(Administrator newAdministrator);
    }
}