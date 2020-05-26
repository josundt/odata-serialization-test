using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataSerializationTest.Data;
using ODataSerializationTest.Model;
using System.Linq;

namespace ODataSerializationTest.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRespository repository;

        public PeopleController(IPersonRespository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        [EnableQuery]
        public IQueryable<Person> GetPeople()
        {
            return this.repository.People;
        }
    }
}
