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
    public class AdministratorController: ControllerBase 
    {
        private readonly IAdministratorService administratorService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public AdministratorController(MyDataContext context, IAdministratorService administratorService,
         IMapper mapper) {
             this.context = context;
             this.administratorService = administratorService;
             this.mapper = mapper;
         }

        [Authorize(Roles = "Administrator")]
        [HttpPost("addadmin")]
        public async Task<IActionResult> RegisterAdministrator([FromBody] AdministratorDto administratorDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == administratorDto.EducationalInstitutionId).FirstOrDefault();
            Administrator newAdministrator = mapper.Map<Administrator>(administratorDto);
            newAdministrator.EducationalInstitution = timeEducationalInstitution;
            newAdministrator = await administratorService.AddAdministrator(newAdministrator);
            return Ok(newAdministrator);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            await administratorService.DeleteAdministrator(id);
            return Ok(new
            {
                Response = "Administrator is deleted successfully"
            });
        }

    }
}