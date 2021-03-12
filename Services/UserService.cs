using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System;
using System.Linq;
using DAL;
using DAL.Entities;
using Services.Models;
using Microsoft.Extensions.Logging;
using Services.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class UserService : IUserService
    {
        private IDataContext context;
        private readonly ILogger<UserService> logger;

        private IConfiguration Configuration;
        public UserService(IDataContext context, ILogger<UserService> logger, IConfiguration configuration)
        {
            this.context = context;
            this.logger = logger;
            Configuration = configuration;
        }

        public UserDto GetUserById(int userId)
        {
            var user = context.Users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            var fullName = string.Format("{0} {1}", user.FirstName, user.LastName);
            var dob = user.DateOfBirth ?? DateTime.Now;
            return new UserDto { UserId = user.UserId, UserName = user.UserName, FullName = fullName, DateOfBirth = dob };
        }

        public UserDto GetUserByUserName(string userName)
        {
            throw new TheoException("this is a fake theo exception");
            // var user = context.Users.Where(user => user.LastName.ToUpper() == userName.ToUpper()).FirstOrDefault();
            // if (user == null)
            // {
            //     return null;
            // }
            // var fullName = string.Format("{0} {1}", user.FirstName, user.LastName);
            // var dob = user.DateOfBirth ?? DateTime.Now;
            // return new UserDto { FullName = fullName, DateOfBirth = dob };
        }

        public Boolean CreateUser(CreateUserDto createUserDto)
        {
            context.Users.Add(new User { UserName = createUserDto.UserName, Password = createUserDto.Password, FirstName = createUserDto.FirstName, LastName = createUserDto.LastName });
            context.SaveChanges();
            logger.LogInformation("A new user has been created, {name}", string.Format("{0} {1}", createUserDto.FirstName, createUserDto.LastName));
            return true;
        }

        public LoginResponseDto AuthenticateUser(LoginRequestDto loginRequest)
        {
            var user = context.Users.SingleOrDefault(x => x.UserName == loginRequest.UserName && x.Password == loginRequest.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new LoginResponseDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Token = token
            };
        }



        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, ((UserRoleEnum)user.UserRole).ToString()),
                    new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


    }
}