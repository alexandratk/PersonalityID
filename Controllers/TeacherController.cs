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

        [HttpPost("addteacher")]
        public async Task<IActionResult> RegisterTeacher([FromBody] TeacherDto teacherDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == teacherDto.EducationalInstitutionId).FirstOrDefault();
            Teacher newTeacher = mapper.Map<Teacher>(teacherDto);
            newTeacher.EducationalInstitution = timeEducationalInstitution;
            newTeacher = await TeacherService.AddTeacher(newTeacher);
            return Ok(newTeacher);
        }
    }
}