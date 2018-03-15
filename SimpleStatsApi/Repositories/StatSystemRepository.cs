using System;
using System.Linq;
using System.Collections.Generic;

using SimpleStatsApi.Models.DTOModels;
using SimpleStatsApi.Models.EntityModels;
using SimpleStatsApi.Models.ViewModels;
using SimpleStatsApi.Utilities.Exceptions;

namespace SimpleStatsApi.Repositories
{
    public class StatSystemRepository : IStatSystemRepository
    {
        private readonly AppDataContext _db;

        public StatSystemRepository(AppDataContext db)
        {
            _db = db;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = (from u in _db.Users
                            where u.isDeleted != 1
                            select new UserDTO
                            {
                                id = u.id,
                                firstName = u.firstName,
                                lastName = u.lastName,
                                email = u.email
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

        public UserDTO AddNewUser(UserViewModel newUser)
        {
            var userEntity = new User
            {
                firstName = newUser.firstName,
                lastName = newUser.lastName,
                email = newUser.email,
                isDeleted = 0,
                password = newUser.password
            };

            try
            {
                _db.Users.Add(userEntity);
                _db.SaveChanges();

                return new UserDTO
                {
                    id = userEntity.id,
                    firstName = userEntity.firstName,
                    lastName = userEntity.lastName,
                    email = userEntity.email
                };
            }
            catch
            {
                throw new AddUserException();
            }
        }

        public void deleteUser(int id)
        {
            var user = _db.Users.Where(u => u.id == id).SingleOrDefault();

            if(user == null)
            {
                throw new UserNotFoundException();
            }

            user.isDeleted = 1;
            _db.SaveChanges();
        }
    }
}
