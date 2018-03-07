using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleStatsApi.Services;

using SimpleStatsApi.Models.DTOModels;
using SimpleStatsApi.Utilites.Exceptions;

namespace Api.Controllers
{
    //[Route("api/[controller]")]
    public class StatsController : Controller
    {
        private readonly IUsersService _usersService;

        public StatsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET api/users
        [HttpGet]
        [Route("api/users", Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            IEnumerable<UserDTO> users;

            users = _usersService.GetAllUsers();
            
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
                user = _usersService.GetUserById(id);
            }
            catch(UserNotFoundException error)
            {
                return NotFound(error.Message);
            }
            
            return Ok(user);
        }
    }
}
