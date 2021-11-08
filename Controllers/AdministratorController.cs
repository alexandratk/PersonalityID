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
    public class AdministratorController: ControllerBase 
    {
        private readonly IAdministratorService AdministratorService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public AdministratorController(MyDataContext context, IAdministratorService AdministratorService,
         IMapper mapper) {
             this.context = context;
             this.AdministratorService = AdministratorService;
             this.mapper = mapper;
         }

        [HttpPost("addadmin")]
        public async Task<IActionResult> RegisterAdministrator([FromBody] AdministratorDto administratorDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == administratorDto.EducationalInstitutionId).FirstOrDefault();
            Administrator newAdministrator = mapper.Map<Administrator>(administratorDto);
            newAdministrator.EducationalInstitution = timeEducationalInstitution;
            newAdministrator = await AdministratorService.AddAdministrator(newAdministrator);
            return Ok(newAdministrator);
        }
    }
}