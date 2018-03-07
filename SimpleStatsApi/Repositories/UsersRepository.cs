using System;
using System.Linq;
using System.Collections.Generic;

using SimpleStatsApi.Models.DTOModels;
using SimpleStatsApi.Utilites.Exceptions;

namespace SimpleStatsApi.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDataContext _db;

        public UsersRepository(AppDataContext db)
        {
            _db = db;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = (from user in _db.Users
                            select new UserDTO
                            {
                                id = user.id,
                                firstName = user.firstName,
                                lastName = user.lastName,
                                email = user.email
                            }).ToList();
            return users;
        }

        public UserDTO GetUserById(int id)
        {
            var user = (from u in _db.Users
                            where u.id == id && u.isDeleted != 1
                            select new UserDTO
                            {
                                id = u.id,
                                firstName = u.firstName,
                                lastName = u.lastName,
                                email = u.email
                            }).SingleOrDefault();
           
            if(user == null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }
    }
}
