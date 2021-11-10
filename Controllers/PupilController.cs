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

        [Authorize(Roles = "Administrator")]
        [HttpPost("addpupil")]
        public async Task<IActionResult> RegisterPupil([FromBody] PupilDto pupilDto)
        {
            var newPupil = await PupilService.AddPupil(pupilDto);
            return Ok(newPupil);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePupil(int id)
        {
            await PupilService.DeletePupil(id);
            return Ok(new
            {
               Response = "Pupil is deleted successfully"
            });
        }
    }
}