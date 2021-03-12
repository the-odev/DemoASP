using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using DAL;
using DAL.Entities;
using Microsoft.Extensions.Logging;
using Services.Models;

namespace Services
{
    public class UserService : IUserService
    {

        private readonly ILogger<UserService> logger;
        private IDataContext context;

        public UserService(IDataContext context, ILogger<UserService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public UserDto GetUserById(int userId)
        {
            var user = context.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (user == null)
            {
                throw new HttpRequestException("User not found", null, HttpStatusCode.NotFound);
            }
            return new UserDto { FullName = string.Format("{0} {1}", user.FirstName, user.LastName), DateOfBirth = user.DateOfBirth ?? null };
        }

        public UserDto GetUserByName(string userName)
        {
            var user = context.Users.Where(u => u.LastName.ToUpper().Contains(userName.ToUpper())).FirstOrDefault();
            if (user == null)
            {
                throw new HttpRequestException("User not found", null, HttpStatusCode.NotFound);
            }
            return new UserDto { FullName = string.Format("{0} {1}", user.FirstName, user.LastName), DateOfBirth = user.DateOfBirth ?? null };
        }

        public Boolean CreateUser(CreateUserDto createUserDto)
        {
            context.Users.Add(new User { FirstName = createUserDto.FirstName, LastName = createUserDto.LastName, DateOfBirth = createUserDto.DateOfBirth ?? null });
            context.SaveChanges();
            logger.LogInformation("A new user has been created, {name}", string.Format("{0} {1}", createUserDto.FirstName, createUserDto.LastName));
            return true;
        }
    }
}