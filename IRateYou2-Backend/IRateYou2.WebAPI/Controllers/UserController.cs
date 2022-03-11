using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IRateYou2.Core.IServices;
using IRateYou2.Core.Models;

namespace IRateYou2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService  userService)
        {
            _userService = userService;
        }
        
        // Create
        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            try
            {
                return Ok(_userService.CreateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Read
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet ("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _userService.GetUserById(id);
        }
        
        // Update
        [HttpPut("{id}")]
        public ActionResult<User> Update(int id, [FromBody] User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return BadRequest("Parameter ID and User ID has to match.");
                }

                return Ok(_userService.UpdateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // Delete
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            try
            {
                return Ok(_userService.DeleteUserById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}