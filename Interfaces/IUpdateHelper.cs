using System.Threading.Tasks;

namespace PersonalityID.Interfaces
{
    public interface IUpdateHelper
    {
        Task<Entity> updateEntity<Entity, EntityDto>(EntityDto entityDto, params int[] id);
    }
}