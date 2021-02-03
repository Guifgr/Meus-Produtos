using Meus_Produtos.Models;
using Meus_Produtos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_Produtos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public ActionResult GetAllPeople()
        {
            //This return will check in the DB all persons and return an Object with all person objects
            return Ok(_personService.FindAll());
        }

        [HttpGet("{param}")]
        public IActionResult GetPersonById(long param)
        {
            long Id = param;
            //Get Person and save in a variable 
            var person = _personService.FindById(Id);
            
            //Check if .this person exists if !exists then return an 404 not found
            if (person == null) return NotFound();
            
            //If the person with the specifield id exists then will return all the data from the DB in an single object
            return Ok(person);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            //If the person object !exists then will return an BadRequest 
            if (person == null) return BadRequest();
            //If all person data is ok then will create an new person and save in the DB
            if (_personService.Create(person) == null)
            {
                return BadRequest(new { UserEmail = "This email alredy exists in our dataBase" });
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            //If the person object !exists then will return an BadRequest 
            if (person == null) return BadRequest();
            //If all person data is ok then will Update person and save in the DB
            return Ok(_personService.Update(person));
        }


        [HttpDelete("{param}")]
        public IActionResult DeletePersonById(long param)
        {
            long id = param;
            //Get Person and save in a variable 
            _personService.Delete(id);

            //If the person with the specifield id exists then will return all the data from the DB in an single object
            return NoContent();
        }
    }
}
