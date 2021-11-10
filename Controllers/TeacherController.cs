using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class TeacherController: ControllerBase 
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public TeacherController(MyDataContext context, ITeacherService teacherService,
         IMapper mapper) {
             this.context = context;
             this.teacherService = teacherService;
             this.mapper = mapper;
         }

        [Authorize(Roles = "Administrator")]
        [HttpPost("addteacher")]
        public async Task<IActionResult> RegisterTeacher([FromBody] TeacherDto teacherDto)
        {
            var newTeacher = await teacherService.AddTeacher(teacherDto);
            return Ok(newTeacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await teacherService.DeleteTeacher(id);
            return Ok(new
            {
               Response = "Teacher is deleted successfully"
            });
        }
    }
}