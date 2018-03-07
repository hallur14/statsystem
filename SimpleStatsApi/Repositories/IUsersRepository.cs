using System.Collections.Generic;
using SimpleStatsApi.Models.DTOModels;

namespace SimpleStatsApi.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<UserDTO> GetAllUsers();

        UserDTO GetUserById(int id);
    }
}