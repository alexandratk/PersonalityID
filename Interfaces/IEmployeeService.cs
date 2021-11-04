using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IEmployeeService
    {
         Task<Employee> AddEmployee(Employee newEmployee);
    }
}