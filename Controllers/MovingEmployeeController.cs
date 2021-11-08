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
    public class MovingEmployeeController: ControllerBase 
    {
        private readonly IMovingEmployeeService MovingEmployeeService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public MovingEmployeeController(MyDataContext context, IMovingEmployeeService MovingEmployeeService,
         IMapper mapper) {
             this.context = context;
             this.MovingEmployeeService = MovingEmployeeService;
             this.mapper = mapper;
         }

        [HttpPost("addmovemp")]
        public async Task<IActionResult> RegisterMovingEmployee([FromBody] MovingEmployeeDto movingEmployeeDto)
        {
            Device timeDevice = context.Device.Where(c => c.Id == movingEmployeeDto.DeviceId).FirstOrDefault();
            Employee timeEmployee = context.Employee.Where(c => c.Id == movingEmployeeDto.EmployeeId).FirstOrDefault();
            MovingEmployee newMovingEmployee = mapper.Map<MovingEmployee>(movingEmployeeDto);
            newMovingEmployee.Device = timeDevice;
            newMovingEmployee.Employee = timeEmployee;
            newMovingEmployee = await MovingEmployeeService.AddMovingEmployee(newMovingEmployee);
            return Ok(newMovingEmployee);
        }
    }
}