using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Model;
using RestWithASPNET5.Services;

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
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personservice)
        {
            _logger = logger;
            //Recebe a injeção de dependência no construtor
            _personService = personservice;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }       
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            
            if (person == null) return BadRequest();

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null) return BadRequest();

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();

            _personService.Delete(id);  
            
            return NoContent();
        }



    }
}
