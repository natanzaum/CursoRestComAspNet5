using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Model;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASPNET5.Controllers
{
    //Define a versão da Controller
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
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
        [ProducesResponseType(200, Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {

            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpGet("personByName")]
        [ProducesResponseType(200, Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult PersonById([FromQuery] string fristName, [FromQuery] string lastName)
        {
            var person = _personBusiness.FindPersonByName(fristName, lastName);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            
            if (person == null) return BadRequest();

            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {

            if (person == null) return BadRequest();

            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();

            _personBusiness.Delete(id);  
            
            return NoContent();
        }



    }
}
