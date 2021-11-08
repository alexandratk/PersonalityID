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
    public class PupilController: ControllerBase 
    {
        private readonly IPupilService PupilService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public PupilController(MyDataContext context, IPupilService PupilService,
         IMapper mapper) {
             this.context = context;
             this.PupilService = PupilService;
             this.mapper = mapper;
         }

        [HttpPost("addpupil")]
        public async Task<IActionResult> RegisterPupil([FromBody] PupilDto pupilDto)
        {
            Pupil newPupil = mapper.Map<Pupil>(pupilDto);
            newPupil = await PupilService.AddPupil(newPupil);
            return Ok(newPupil);
        }
    }
}