using System.Collections.Generic;
using IRateYou2.Core.Models;

namespace IRateYou2.Core.IServices
{
    public interface IUserService
    {
        // Create
        User CreateUser(User user);
        
        // Read
        List<User> GetAllUsers();
        User GetUserById(int id);
        
        // Update
        User UpdateUser(User user);
        
        // Delete
        User DeleteUserById(int id);
    }
}