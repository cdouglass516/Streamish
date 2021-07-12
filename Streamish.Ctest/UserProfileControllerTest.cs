using Streamish.Controllers;
using Streamish.Models;
using Streamish.Ctest.Moqs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Streamish.Ctest
{
    public class UserProfileControllerTest
    {
        private UserProfile CreateTestUserProfile(int id)
        {
            return new UserProfile()
            {
                Id = id,
                Name = $"User {id}",
                Email = $"user{id}@example.com",
                DateCreated = DateTime.Today.AddDays(-id),
                ImageUrl = $"http://user.url/{id}",
            };
        }
        private List<UserProfile> CreateTestUsers(int countUsers)
        {
            var Users = new List<UserProfile>();
            for(int i =0; i < countUsers; i++)
            {
                Users.Add(CreateTestUserProfile(i));
            }

            return Users;
        }

        [Fact]
        public void Get_Returns_All_Users()
        {
            // Arrange 
            var userCount = 10;
            var users = CreateTestUsers(userCount);

            var repo = new InMemoryUserProfileRepository(users);
            var controller = new UserProfileController(repo);

            // Act 
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualUsers = Assert.IsType<List<UserProfile>>(okResult.Value);

            Assert.Equal(userCount, actualUsers.Count);
            Assert.Equal(users, actualUsers);
        }
        [Fact]
        public void Get_Return_User()
        {
            // Arrange 
            var userCount = 10;
            var users = CreateTestUsers(userCount);

            var repo = new InMemoryUserProfileRepository(users);
            var controller = new UserProfileController(repo);

            // Act 
            var result = controller.GetById(4);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualUsers = Assert.IsType<UserProfile>(okResult.Value);
            var test = okResult.Value;
            //Assert.Equal(users, actualUsers);
        }
    }
}

