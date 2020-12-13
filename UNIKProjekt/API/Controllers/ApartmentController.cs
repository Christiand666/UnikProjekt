using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Handlers;
using Domain.Models;
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
            List<Apartment> ApartmentResponse = apartmentHandler.GetAll();

            if (ApartmentResponse != null)
                return Ok(ApartmentResponse);
            else
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Some error",
                    ErrorCode = 502
                };
                return StatusCode(502, err);
            }
        }

        [HttpGet]
        [Route("GetItem")]
        public IActionResult GetApartment(string ID)
        {
            Apartment ApartmentResponse = apartmentHandler.GetApartment(ID);

            if (ApartmentResponse != null)
                return Ok(ApartmentResponse);
            else
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Some error",
                    ErrorCode = 502
                };
                return StatusCode(502, err);
            }
        }
    }
}
