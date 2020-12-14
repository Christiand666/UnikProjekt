using API.Models;
using Application.Handlers;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler userHandler;
       public UserController(IUserHandler userHandler)
       {
            this.userHandler = userHandler;
       }
       [HttpPost]
       public IActionResult CreateUser([FromBody] User user) { 
            try
            {
                userHandler.CreateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to create user",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
       }
        [HttpGet] 
        public ActionResult<User> GetUserById([FromBody] string id)
        {
            try
            {
                var match = userHandler.GetUsersByID(id);
                return Ok(match);
            }
            catch (Exception e)
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to find user",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                var match = userHandler.GetAllUsers();
                return Ok(match);
            } 
            catch (Exception e)
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to get users",
                    ErrorCode = 502, 
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
           {
             try
             {
                 userHandler.UpdateUser(user);
                 return Ok();
             }
             catch (Exception e)
             {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to update user",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
             } 
        }
        [HttpDelete]
        public IActionResult DeleteUser([FromBody] User user)
        {
            try
            {
                userHandler.DeleteUsers(user.UserID);
                return Ok();
            }
            catch (Exception e)
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to delete user",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }
    }
}
