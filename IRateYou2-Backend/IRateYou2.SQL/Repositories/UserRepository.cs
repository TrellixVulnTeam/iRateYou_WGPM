using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using IRateYou2.Core.Models;
using IRateYou2.Domain.IRepositories;

namespace IRateYou2.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _ctx;

        public UserRepository(DBContext ctx)
        {
            _ctx = ctx;
        }

        public User CreateUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Added;
            _ctx.SaveChanges();
            return user;
        }
        
        public User GetUserById(int id)
        {
            var u = _ctx.Users.FirstOrDefault(p => p.Id == id);
            return u;
        }

        public User UpdateUser(User user)
        {
            _ctx.Users.Attach(user).State = EntityState.Modified;
            _ctx.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _ctx.Users.ToList();
        }

        public User DeleteUserById(int id)
        {
            var u = _ctx.Users.FirstOrDefault(p => p.Id == id);
            _ctx.Users.Attach(u).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return u;
        }
    }
}