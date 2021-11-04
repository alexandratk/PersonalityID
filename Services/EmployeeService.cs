using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly MyDataContext database;

        public EmployeeService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Employee> AddEmployee(Employee newEmployee)
        {
            await database.Employee.AddAsync(newEmployee);
            await database.SaveChangesAsync();

            return newEmployee;
        }
    }
}