
using System;
using System.Collections.Generic;
using System.IO;
using IRateYou2.Domain.IRepositories;
using IRateYou2.Core.IServices;
using IRateYou2.Core.Models;

namespace IRateYou2.Domain.Services
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository _userRepo;
        
        public UserService(IUserRepository  userRepo)
        {
            _userRepo = userRepo;
        }

        public User CreateUser(User user)
        {
            if (user.FirstName == null)
                throw new InvalidDataException("User needs a First Name");
            if (user.LastName == null)
                throw new InvalidDataException("User needs a Last Name");
            var u = _userRepo.CreateUser(user);
            return u;
        }
        
        public User GetUserById(int id)
        {
            var u = _userRepo.GetUserById(id);
            return u;
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User UpdateUser(User user)
        {
            var u = _userRepo.UpdateUser(user);
            return u;
        }

        public User DeleteUserById(int id)
        {
            var u = _userRepo.DeleteUserById(id);
            return u;
        }


    }
}