using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Itrefaces
{
    public interface IParentService
    {
         Task<Parent> AddParent(ParentDto newParentDto);
         Task<Parent> UpdateParent(ParentDto newParentDto, int parentId);
         Task DeleteParent(int parentId);
    }
}