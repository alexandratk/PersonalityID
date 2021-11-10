using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using System.Linq;
using System;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class GroupController: ControllerBase 
    {
        private readonly IGroupService groupService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public GroupController(MyDataContext context, IGroupService GroupService,
         IMapper mapper) {
             this.context = context;
             this.groupService = GroupService;
             this.mapper = mapper;
         }

        [HttpPost("addgroup")]
        public async Task<IActionResult> RegisterGroup([FromBody] GroupDto groupDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == groupDto.EducationalInstitutionId).FirstOrDefault();
            Group newGroup = mapper.Map<Group>(groupDto);
            newGroup.EducationalInstitution = timeEducationalInstitution;
            newGroup = await groupService.AddGroup(newGroup);
            return Ok(newGroup);
        }

        [HttpPost("addpupiltogroup")]
        public async Task<IActionResult> RegisterGroup([FromBody] GroupPupilDto groupPupilDto)
        {
            Group currentGroup = await groupService.AddPupilToGroup(groupPupilDto);
            return Ok(currentGroup);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await groupService.DeleteGroup(id);
            return Ok(new
            {
               Response = "Group is deleted successfully"
            });
        }
    }
}