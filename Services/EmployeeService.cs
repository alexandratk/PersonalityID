using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MyDataContext database;
        private readonly IAuthHelper<Employee, EmployeeDto> authHelper;
        private readonly IUpdateHelper updateHelper;

        public EmployeeService(MyDataContext database, IAuthHelper<Employee, EmployeeDto> authHelper, IUpdateHelper updateHelper)
        {
            this.database = database;
            this.authHelper = authHelper;
            this.updateHelper = updateHelper;
        }

        public async Task<Employee> AddEmployee(EmployeeDto newEmployeeDto)
        {
            var newEmployee = await authHelper.AddUserToDB(newEmployeeDto);
            EducationalInstitution timeEducationalInstitution = database.EducationalInstitution.Where(c => c.Id == newEmployeeDto.EducationalInstitutionId).FirstOrDefault();
            newEmployee.EducationalInstitution = timeEducationalInstitution;

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

        public async Task<Employee> UpdateEmployee(EmployeeDto newEmployeeDto, int employeeId)
        {
            var updatedEmployee = await updateHelper.updateEntity<Employee, EmployeeDto>(newEmployeeDto, employeeId);
            return updatedEmployee;
        }
    }
}