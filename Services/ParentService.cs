using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class ParentService: IParentService
    {
        private readonly MyDataContext database;

        public ParentService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Parent> AddParent(Parent newParent)
        {
            await database.Parent.AddAsync(newParent);
            await database.SaveChangesAsync();

            return newParent;
        }
    }
}