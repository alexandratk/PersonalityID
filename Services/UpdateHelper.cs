using System.Threading.Tasks;
using AutoMapper;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;

namespace PersonalityID.Services
{
    public class UpdateHelper : IUpdateHelper
    {
        private readonly MyDataContext database;
        private readonly IMapper mapper;
        public UpdateHelper(MyDataContext database, IMapper mapper)
        {
            this.mapper = mapper;
            this.database = database;

        }
        public async Task<Entity> updateEntity<Entity, EntityDto>(EntityDto entityDto, params int[] id)
        {
            var entity = database.Find(typeof(Entity), id);

            mapper.Map(entityDto, entity);
            database.Update(entity);
            await database.SaveChangesAsync();

            return (Entity)entity;
        }
    }
}