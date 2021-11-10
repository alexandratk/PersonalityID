using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteEmployee(int EmployeeId)
        {
            var deletingEmployeeDescription =
             await database.Employee.FirstOrDefaultAsync(p => p.Id == EmployeeId);

            if (deletingEmployeeDescription is null)
                throw new System.Exception("No proper place found");

            database.Employee.Remove(deletingEmployeeDescription);
            await database.SaveChangesAsync();

        }
    }
}