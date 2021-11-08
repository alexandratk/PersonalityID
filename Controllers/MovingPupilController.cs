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
    public class MovingPupilController: ControllerBase 
    {
        private readonly IMovingPupilService MovingPupilService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public MovingPupilController(MyDataContext context, IMovingPupilService MovingPupilService,
         IMapper mapper) {
             this.context = context;
             this.MovingPupilService = MovingPupilService;
             this.mapper = mapper;
         }

        [HttpPost("addmovpupil")]
        public async Task<IActionResult> RegisterMovingPupil([FromBody] MovingPupilDto movingPupilDto)
        {
            Device timeDevice = context.Device.Where(c => c.Id == movingPupilDto.DeviceId).FirstOrDefault();
            Pupil timePupil = context.Pupil.Where(c => c.Id == movingPupilDto.PupilId).FirstOrDefault();
            MovingPupil newMovingPupil = mapper.Map<MovingPupil>(movingPupilDto);
            newMovingPupil.Device = timeDevice;
            newMovingPupil.Pupil = timePupil;
            newMovingPupil = await MovingPupilService.AddMovingPupil(newMovingPupil);
            return Ok(newMovingPupil);
        }
    }
}