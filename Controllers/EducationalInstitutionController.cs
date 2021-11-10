using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class EducationalInstitutionController: ControllerBase 
    {
        private readonly IEducationalInstitutionService educationalInstitutionService;
        private readonly IMapper mapper;

        public EducationalInstitutionController(MyDataContext context, IEducationalInstitutionService educationalInstitutionService,
         IMapper mapper) {
             this.educationalInstitutionService = educationalInstitutionService;
             this.mapper = mapper;
         }

        [HttpPost("addeducinst")]
        public async Task<IActionResult> RegisterEducationalInstitution([FromBody] EducationalInstitutionDto educationalInstitutionDto)
        {
            EducationalInstitution newEducationalInstitution = mapper.Map<EducationalInstitution>(educationalInstitutionDto);
            newEducationalInstitution = await educationalInstitutionService.AddEducationalInstitution(newEducationalInstitution);
            return Ok(newEducationalInstitution);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationalInstitution(int id)
        {
            await educationalInstitutionService.DeleteEducationalInstitution(id);
            return Ok(new
            {
               Response = "EducationalInstitution is deleted successfully"
            });
        }
    }
}