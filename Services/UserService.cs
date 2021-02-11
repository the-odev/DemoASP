using System.Net;
using System.Net.Http;
using System;
using System.Linq;
using DAL;
using DAL.Entities;
using Services.Models;

namespace Services
{
    public class UserService : IUserService
    {
        private IDataContext context;

        public UserService(IDataContext context)
        {
            this.context = context;
        }

        public UserDto GetUserById(int userId)
        {
            var user = context.Users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null)
            {
                throw new HttpRequestException("User not found", null, HttpStatusCode.NotFound);
            }
            var fullName = string.Format("{0} {1}", user.FirstName, user.LastName);
            var dob = user.DateOfBirth ?? DateTime.Now;
            return new UserDto { FullName = fullName, DateOfBirth = dob };
        }

        public UserDto GetUserByUserName(string userName) {
            var user = context.Users.Where(user => user.LastName.ToUpper() == userName.ToUpper()).FirstOrDefault();
            if (user == null)
            {
                throw new HttpRequestException("User not found", null, HttpStatusCode.NotFound);
            }
            var fullName = string.Format("{0} {1}", user.FirstName, user.LastName);
            var dob = user.DateOfBirth ?? DateTime.Now;
            return new UserDto { FullName = fullName, DateOfBirth = dob };
        }

        public Boolean CreateUser(CreateUserDto createUserDto)
        {
            context.Users.Add(new User { FirstName = createUserDto.FirstName, LastName = createUserDto.LastName });
            context.SaveChanges();
            return true;
        }
    }
}