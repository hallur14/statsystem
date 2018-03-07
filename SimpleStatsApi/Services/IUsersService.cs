using System;
using System.Collections.Generic;
using SimpleStatsApi.Models.DTOModels;

namespace SimpleStatsApi.Services
{
    public interface IUsersService
    {
        IEnumerable<UserDTO> GetAllUsers();

        UserDTO GetUserById(int id);
    }
}
