using System.Collections.Generic;

using SimpleStatsApi.Models.DTOModels;
using SimpleStatsApi.Models.ViewModels;

namespace SimpleStatsApi.Repositories
{
    public interface IStatSystemRepository
    {
        IEnumerable<UserDTO> GetAllUsers();

        UserDTO GetUserById(int id);

        UserDTO AddNewUser(UserViewModel newUser);

        void deleteUser(int id);
    }
}