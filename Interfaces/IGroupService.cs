using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Itrefaces
{
    public interface IGroupService
    {
         Task<Group> AddGroup(Group newGroup);
         Task<Group> AddPupilToGroup(GroupPupilDto newUser);
         Task DeleteGroup(int groupId);
    }
}