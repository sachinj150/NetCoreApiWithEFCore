using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

namespace Module1.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/movies")]
    [ApiController]
    public class MoviesV2Controller : ControllerBase
    {
        static List<MoviesV2> _movies = new List<MoviesV2>()
        {
            new MoviesV2() {Id = 0, MovieName = "Shahenshah", MovieDescription = "Action film of Amitabh Bachchan", MovieType = "Action"},
            new MoviesV2() {Id = 1, MovieName = "Amar Akbar Anthony", MovieType = "Family", MovieDescription = "Comedy movie of Amitabh Bachchan"}
        };

        // GET: api/MoviesV2
        [HttpGet]
        public IEnumerable<MoviesV2> Get()
        {
            return _movies;
        }

        //// GET: api/MoviesV2/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/MoviesV2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MoviesV2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
