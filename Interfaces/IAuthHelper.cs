using System.Threading.Tasks;

namespace PersonalityID.Interfaces
{
    public interface IAuthHelper<Entity, EntityDto>
    {
         Task<Entity> AddUserToDB(EntityDto newTeacherDto);
    }
}