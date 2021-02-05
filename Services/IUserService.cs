using System;
using Services.Models;

namespace Services
{
    public interface IUserService
    {
         string GetUser();
         Boolean CreateUser(CreateUserDto createUserDto);
    }
}