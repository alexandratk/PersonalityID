using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Itrefaces
{
    public interface IEmployeeService
    {
         Task<Employee> AddEmployee(EmployeeDto newEmployeeDto);
         Task<Employee> UpdateEmployee(EmployeeDto newEmployeeDto, int employeeId);
         Task DeleteEmployee(int employeeId);
    }
}