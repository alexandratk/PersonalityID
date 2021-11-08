using System.Threading.Tasks;
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
    }
}