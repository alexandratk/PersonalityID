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
    public class EmployeeController: ControllerBase 
    {
        private readonly IEmployeeService EmployeeService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public EmployeeController(MyDataContext context, IEmployeeService EmployeeService,
         IMapper mapper) {
             this.context = context;
             this.EmployeeService = EmployeeService;
             this.mapper = mapper;
         }

        [HttpPost("addemployee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] EmployeeDto employeeDto)
        {
            Console.WriteLine(employeeDto.EducationalInstitutionId);
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == employeeDto.EducationalInstitutionId).FirstOrDefault();
            Employee newEmployee = mapper.Map<Employee>(employeeDto);
            newEmployee.EducationalInstitution = timeEducationalInstitution;
            newEmployee = await EmployeeService.AddEmployee(newEmployee);
            return Ok(newEmployee);
        }
    }
}