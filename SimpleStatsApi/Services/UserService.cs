using System.Collections.Generic;

using SimpleStatsApi.Models.DTOModels;
using SimpleStatsApi.Models.ViewModels;
using SimpleStatsApi.Repositories;

namespace SimpleStatsApi.Services
{
    public class UserService : IUserService
    {
        private readonly IStatSystemRepository _repo;

        public UserService(IStatSystemRepository repo)
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

        public UserDTO AddNewUser(UserViewModel newUser)
        {
            var user = _repo.AddNewUser(newUser);

            return user;
        }

        public void deleteUser(int id)
        {
            _repo.deleteUser(id);
        }
    }
}