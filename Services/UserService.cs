using System;
using DAL;
using DAL.Entities;
using Services.Models;

namespace Services
{
    public class UserService : IUserService
    {
        private IDataContext context;

        public UserService(IDataContext context) {
            this.context = context;
        }        

        public string GetUser() {
            return "I am a user";
        }

        public Boolean CreateUser(CreateUserDto createUserDto) {
            context.Users.Add(new User { FirstName = createUserDto.FirstName, LastName = createUserDto.LastName });
            context.SaveChanges();
            return true;
        }
    }
}