using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.ParameterBindings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //Sample DTO class
        public class PersonDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }


        public record MovieDTO(int Id, string MovieName, string Artist);
        public record ResponseDTO(string status, object obj, string message);

        //Sample data
        private static List<PersonDTO> _people = new List<PersonDTO>
        {
            new PersonDTO{Id =  1, Name ="John Doe", Age=30},
            new PersonDTO{Id =  2, Name ="Jane Smith", Age=25},
            new PersonDTO{Id =  3, Name ="Bob Johnson", Age=40}
        };

        [Route("Persons")] //enable app.UseRouting(); in middleware section
        [HttpGet]
        public List<PersonDTO> GetPersons()
        {
            return _people;
        }


        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            if (id == 0)
                return BadRequest(new { status = "failed", obj = "null", message = "id should not be zero or null" });


            var person = _people.Find(p => p.Id == id);

            if (person != null)
                return Ok(person);
            else
                return NotFound(new ResponseDTO("failed", person, $"Person not found with the given id {id}"));
        }

    }
}
