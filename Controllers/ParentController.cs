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
    public class ParentController: ControllerBase 
    {
        private readonly IParentService ParentService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public ParentController(MyDataContext context, IParentService ParentService,
         IMapper mapper) {
             this.context = context;
             this.ParentService = ParentService;
             this.mapper = mapper;
         }

        [HttpPost("addparent")]
        public async Task<IActionResult> RegisterParent([FromBody] ParentDto parentDto)
        {
            Parent newParent = mapper.Map<Parent>(parentDto);
            newParent = await ParentService.AddParent(newParent);
            return Ok(newParent);
        }
    }
}