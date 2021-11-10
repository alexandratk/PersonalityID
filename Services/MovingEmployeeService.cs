using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class MovingEmployeeService: IMovingEmployeeService
    {
        private readonly MyDataContext database;

        public MovingEmployeeService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<MovingEmployee> AddMovingEmployee(MovingEmployee newMovingEmployee)
        {
            await database.MovingEmployee.AddAsync(newMovingEmployee);
            await database.SaveChangesAsync();

            return newMovingEmployee;
        }

        public async Task DeleteMovingEmployee(int MovingEmployeeId)
        {
            var deletingMovingEmployeeDescription =
             await database.MovingEmployee.FirstOrDefaultAsync(p => p.Id == MovingEmployeeId);

            if (deletingMovingEmployeeDescription is null)
                throw new System.Exception("No proper MovingEmployee found");

            database.MovingEmployee.Remove(deletingMovingEmployeeDescription);
            await database.SaveChangesAsync();

        }
    }
}