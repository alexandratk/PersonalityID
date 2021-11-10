using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class ParentService: IParentService
    {
        private readonly MyDataContext database;
        private readonly IAuthHelper<Parent, ParentDto> authHelper;
        private readonly IUpdateHelper updateHelper;

        public ParentService(MyDataContext database, 
                            IAuthHelper<Parent, ParentDto> authHelper,
                            IUpdateHelper updateHelper)
        {
            this.database = database;
            this.authHelper = authHelper;
            this.updateHelper = updateHelper;
        }

        public async Task<Parent> AddParent(ParentDto newParentDto)
        {
            var newParent = await authHelper.AddUserToDB(newParentDto);
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

        public async Task<Parent> UpdateParent(ParentDto newParentDto, int parentId)
        {
            var updatedParent = await updateHelper.updateEntity<Parent, ParentDto>(newParentDto, parentId);
            return updatedParent;
        }
    }
}