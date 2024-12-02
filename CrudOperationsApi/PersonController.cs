using CrudOperationsApi.Models;
using CrudOperationsApi.Services;
using Microsoft.AspNetCore.Mvc;
using CrudOperationsApi.Models;
using CrudOperationsApi.Services;
using System.Collections.Generic;

namespace CrudOperationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public PersonController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // GET: api/person
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPersons()
        {
            var persons = _databaseService.GetPersons();
            return Ok(persons);
        }

        // GET: api/person/{id}
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = _databaseService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // POST: api/person
        [HttpPost]
        public ActionResult PostPerson([FromBody] Person person)
        {
            _databaseService.AddPerson(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        // PUT: api/person/{id}
        [HttpPut("{id}")]
        public ActionResult PutPerson(int id, [FromBody] Person person)
        {
            var existingPerson = _databaseService.GetPersonById(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            person.Id = id;
            _databaseService.UpdatePerson(person);
            return NoContent();
        }

        // DELETE: api/person/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var existingPerson = _databaseService.GetPersonById(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            _databaseService.DeletePerson(id);
            return NoContent();
        }
    }
}
