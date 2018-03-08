using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleStatsApi.Services;

using SimpleStatsApi.Models.DTOModels;
using SimpleStatsApi.Models.ViewModels;
using SimpleStatsApi.Utilities.Exceptions;

namespace Api.Controllers
{
    public class StatsController : Controller
    {
        private readonly IUserService _userService;

        public StatsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        [Route("api/users", Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            IEnumerable<UserDTO> users;

            users = _userService.GetAllUsers();
            
            return Ok(users);
        }

        // GET api/users/{id}
        [HttpGet]
        [Route("api/users/{id:int}", Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {
            UserDTO user;

            try
            {
                user = _userService.GetUserById(id);
            }
            catch(UserNotFoundException error)
            {
                return NotFound(error.Message);
            }
            
            return Ok(user);
        }

        // Post api/users
        [HttpPost]
        [Route("api/users", Name = "AddUser")]
        public IActionResult AddUser([FromBody]UserViewModel newUser)
        {
            if(newUser == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return StatusCode(412);
            }

            try
            {
                var user = _userService.AddNewUser(newUser);

                return Ok(user);
            }
            catch(UserNotFoundException error)
            {
                return StatusCode(503, error.Message);
            }        
        }

        // api/user/{id}
        [HttpDelete]
        [Route("api/users/{id:int}", Name = "DeleteUser")]
        public IActionResult deleteUser(int id)
        {
            try
            {
                _userService.deleteUser(id);

                return NoContent();
            }
            catch(UserNotFoundException error)
            {
                return StatusCode(404, error.Message);
            }

        }
    }
}
