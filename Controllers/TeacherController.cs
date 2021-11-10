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
        private readonly ITeacherService TeacherService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public TeacherController(MyDataContext context, ITeacherService TeacherService,
         IMapper mapper) {
             this.context = context;
             this.TeacherService = TeacherService;
             this.mapper = mapper;
         }

        [Authorize(Roles = "Administrator")]
        [HttpPost("addteacher")]
        public async Task<IActionResult> RegisterTeacher([FromBody] TeacherDto teacherDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == teacherDto.EducationalInstitutionId).FirstOrDefault();
            Teacher newTeacher = mapper.Map<Teacher>(teacherDto);
            newTeacher.EducationalInstitution = timeEducationalInstitution;
            newTeacher = await TeacherService.AddTeacher(newTeacher);
            return Ok(newTeacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await TeacherService.DeleteTeacher(id);
            return Ok(new
            {
               Response = "Teacher is deleted successfully"
            });
        }
    }
}