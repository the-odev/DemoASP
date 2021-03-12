using System;
using Services.Models;

namespace Services
{
    public interface IUserService
    {
         UserDto GetUserById(int userId);
         UserDto GetUserByName(string userName);
         Boolean CreateUser(CreateUserDto createUserDto);
    }
}