using System.Collections.Generic;
using SimpleStatsApi.Models.DTOModels;
using SimpleStatsApi.Repositories;

namespace SimpleStatsApi.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repo;

        public UsersService(IUsersRepository repo)
        {
            _repo = repo;
        }
        
        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _repo.GetAllUsers();

            return users;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _repo.GetUserById(id);

            return user;
        }
    }
}