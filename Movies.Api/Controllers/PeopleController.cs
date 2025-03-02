
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Interfaces;
using Movies.Api.Models;
using Movies.Data.Models;

namespace Movies.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonManager personManager;

        public PeopleController(IPersonManager personManager)
        {
            this.personManager = personManager;
        }

        [HttpGet("people")]
        public IEnumerable<PersonDto> GetPeople([FromQuery] int limit = int.MaxValue)
        {
            return personManager.GetAllPeople(0, limit);
        }

        [HttpGet("people/{personId}")]
        public IActionResult GetPerson(uint personId)
        {
            PersonDto? person = personManager.GetPerson(personId);

            if (person is null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet("actors")]
        public IEnumerable<PersonDto> GetActors([FromQuery]int limit = int.MaxValue)
        {
            return personManager.GetAllPeople(PersonRole.Actor, 0, limit);
        }
        [HttpGet("directors")]
        public IEnumerable<PersonDto> GetDirectors([FromQuery] int limit = int.MaxValue)
        {
            return personManager.GetAllPeople(PersonRole.Director, 0, limit);
        }

        [HttpPost("people")]
        public IActionResult AddPerson([FromBody] PersonDto personDto)
        {
            PersonDto? addedPerson = personManager.AddPerson(personDto);
            return CreatedAtAction(nameof(GetPerson), new { personId = addedPerson.PersonId }, addedPerson);
        }

        [HttpPut("people/{personId}")]
        public IActionResult UpdatePerson(uint personId, [FromBody] PersonDto personDto)
        {
            PersonDto? updatedPerson = personManager.UpdatePerson(personId, personDto);
            if(updatedPerson is null)
                return NotFound();
            return Ok(updatedPerson);
        }

        [HttpDelete("people/{personId}")]
        public IActionResult DeletePerson(uint personId)
        {
            PersonDto? deletedPerson = personManager.DeletePerson(personId);
            if (deletedPerson is null)
                return NotFound();
            return Ok(deletedPerson);
        }
    }
}
