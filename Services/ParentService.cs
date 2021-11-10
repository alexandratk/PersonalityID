using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteParent(int ParentId)
        {
            var deletingParentDescription =
             await database.Parent.FirstOrDefaultAsync(p => p.Id == ParentId);

            if (deletingParentDescription is null)
                throw new System.Exception("No proper Parent found");

            database.Parent.Remove(deletingParentDescription);
            await database.SaveChangesAsync();

        }
    }
}