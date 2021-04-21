using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Model;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;

namespace RestWithASPNET5.Controllers
{
    //Define a versão da Controller
    [ApiVersion("1")]
    [ApiController]
    //Faz o versionamento na rota da controller
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        //Injeção de dependência do serviço
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            //Recebe a injeção de dependência no construtor
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }       
        
        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            
            if (person == null) return BadRequest();

            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {

            if (person == null) return BadRequest();

            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();

            _personBusiness.Delete(id);  
            
            return NoContent();
        }



    }
}
