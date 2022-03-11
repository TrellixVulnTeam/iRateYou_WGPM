using System;
using System.IO;
using IRateYou2.Core.IServices;
using IRateYou2.Core.Models;
using IRateYou2.Domain.IRepositories;
using IRateYou2.Domain.Services;
using Moq;
using Xunit;

namespace IRateYou2.Core.Test
{
    public class UnitTest1 
    {
        
        [Fact]
        public void CreateUserWithoutFirstName()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService service = 
                new UserService(userRepo.Object);
            var user = new User()
            {
                Id = 1,
                // FirstName = "Ja da",
                LastName = "Hey"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateUser(user));
            
            Assert.Equal("User needs a First Name", ex.Message);
        }
    }
}