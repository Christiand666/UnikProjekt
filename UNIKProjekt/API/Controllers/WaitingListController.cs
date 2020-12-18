using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Handlers;
using Domain.Models;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class WaitingListController : ControllerBase
    {

        private readonly IWaitingListPrio WaitingListHandler;
        
        public WaitingListController(IWaitingListPrio WaitingListHandler)
        {
            this.WaitingListHandler = WaitingListHandler;
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult CreateWaitingList([FromBody] WaitingList List)
        {
            try
            {
                WaitingListHandler.Create(List);
                return Ok();
            }
            catch (Exception e)
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to add you to the waiting list",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }

        }

        [HttpPost]
        [Route("Remove")]
        public IActionResult RemoveWaitingList([FromBody] WaitingList list)
        {
            try
            {
                WaitingListHandler.Remove(list.UserID, list.ApartmentID);
                return Ok();
            }
            catch (Exception e)
            {
                ErrorMessage err = new ErrorMessage
                {
                    Message = "Failed to delete waiting entry",
                    ErrorCode = 502,
                    Exception = e.Message
                };
                return StatusCode(502, err);
            }
        }
        
        [HttpGet]
        public IActionResult GetAllWaitingLists([FromBody] WaitingList list)
        {
            try
            {
                var WaitingList = WaitingListHandler.GetAllWaitingLists(list.UserID);
                return Ok(WaitingList);
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
