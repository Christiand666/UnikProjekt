using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Handlers;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                    ErrorCode = 502,
                    Exception = JsonConvert.SerializeObject(ApartmentResponse)
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

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateApartment([FromBody] Apartment apartmentModel, string LandlordID, string Password) {
            try
            {
                apartmentHandler.CreateApartment(apartmentModel, LandlordID, Password);
                return Ok();
            }
            catch (Exception e)
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to create apartment",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateApartment([FromBody] Apartment apartment, string UID, string Pwd) {
            try
            {
                apartmentHandler.UpdateApartment(apartment, UID, Pwd);
                return Ok();
            } catch(Exception e) {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to update apartment",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }

        [HttpPost]
        [Route("AddWish")]
        public IActionResult AddToWishList([FromBody] Wishlist wish) {
            try
            {
                apartmentHandler.AddWish(wish);
                return Ok();
            } catch(Exception e) {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Der skete en fejl ved opskrivningen. Prøv igen.",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }

        [HttpGet]
        [Route("WishlistAll")]
        public IActionResult GetAllFromWishlist() {
            List<WaitingList> wl = apartmentHandler.GetAllFromWishlist();
            
            try
            {
                return Ok(wl);
            } catch(Exception e) {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Der skete en fejl ved hentningen af listen.",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }

        [HttpGet]
        [Route("MyWishlist")]
        public IActionResult GetWishlistById(string id) {
            List<WaitingList> wl = apartmentHandler.GetWishlistById(id);
            
            try
            {
                return Ok(wl);
            } catch(Exception e) {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Der skete en fejl ved hentningen af listen.",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }
    }
}
