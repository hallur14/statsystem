using System;
using System.Collections.Generic;

using SimpleStatsApi.Models.DTOModels;
using SimpleStatsApi.Models.ViewModels;

namespace SimpleStatsApi.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();

        UserDTO GetUserById(int id);

        UserDTO AddNewUser(UserViewModel newUser);

        void deleteUser(int id);
    }
}
