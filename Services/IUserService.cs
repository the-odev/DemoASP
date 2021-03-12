using System;
using Services.Models;

namespace Services
{
    public interface IUserService
    {
         UserDto GetUserById(int userId);
         UserDto GetUserByUserName(string userName);
         Boolean CreateUser(CreateUserDto createUserDto);

         LoginResponseDto AuthenticateUser(LoginRequestDto loginRequest);
    }
}