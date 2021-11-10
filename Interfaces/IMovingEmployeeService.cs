using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IMovingEmployeeService
    {
         Task<MovingEmployee> AddMovingEmployee(MovingEmployee newMovingEmployee);
         Task DeleteMovingEmployee(int movingEmployeeId);
    }
}