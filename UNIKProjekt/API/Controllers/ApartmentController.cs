using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentHandler apartmentHandler;

        public ApartmentController(IApartmentHandler apartmentHandler)
        {
            this.apartmentHandler = apartmentHandler;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllApartments()
        {

            List<Domain.Models.Apartment> ApartmentResponse = apartmentHandler.GetAll();
            /*var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new Apartment {  }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");*/
            //return Request.
            //return StatusCode(500, "Du så fucking lort.");
            return Ok(ApartmentResponse);
            //return JsonConvert.SerializeObject(apartmentHandler.GetAll());
        }
    }
}
