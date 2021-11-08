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
    public class DeviceController: ControllerBase 
    {
        private readonly IDeviceService DeviceService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public DeviceController(MyDataContext context, IDeviceService DeviceService,
         IMapper mapper) {
             this.context = context;
             this.DeviceService = DeviceService;
             this.mapper = mapper;
         }

        [HttpPost("adddevice")]
        public async Task<IActionResult> RegisterDevice([FromBody] DeviceDto deviceDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == deviceDto.EducationalInstitutionId).FirstOrDefault();
            Device newDevice = mapper.Map<Device>(deviceDto);
            newDevice.EducationalInstitution = timeEducationalInstitution;
            newDevice = await DeviceService.AddDevice(newDevice);
            return Ok(newDevice);
        }
    }
}