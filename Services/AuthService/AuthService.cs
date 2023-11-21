using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication1.Services.AuthService
{
    using BCrypt.Net;
    using MongoDB.Driver;
    using WebApplication1.Models.Auth;

    public class AuthService {
        private readonly IMongoCollection<User> _auth;
        private readonly IConfiguration _configuration;
        public AuthService(IMongoClient mongoClient, IConfiguration configuration)
        {
            var database = mongoClient.GetDatabase("capstone");
            _auth = database.GetCollection<User>("Auth");
            _configuration = configuration;
        }
        public async Task<User> Login(string userName, string password)
    {
        User? user = await _auth.Find(x=> x.UserName == userName).FirstOrDefaultAsync();

        if (user == null || BCrypt.Verify(password, user.Password) == false)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.GivenName, user.Name),
            }),
            IssuedAt = DateTime.UtcNow,
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"],
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        user.Token = tokenHandler.WriteToken(token);
        user.IsActive = true;

        return user;
    }

        public async Task<User> Register(User user)
        {
            user.Password = BCrypt.HashPassword(user.Password);
            return user;
        }

        public async Task<User> RegiserUser(User userRegister)
        {
            var user = await _auth.Find(x => x.UserName == userRegister.UserName).FirstOrDefaultAsync();
            if (user == null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userRegister.UserName),
                    new Claim(ClaimTypes.GivenName, userRegister.Name),
                    }),
                    IssuedAt = DateTime.UtcNow,
                    Issuer = _configuration["JWT:Issuer"],
                    Audience = _configuration["JWT:Audience"],
                    Expires = DateTime.UtcNow.AddDays(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                userRegister.Token = tokenHandler.WriteToken(token);
                userRegister.IsActive = true;
                return userRegister;
            }

            else
            {
                return null;
            }

        }


        public async void insertUser(User user)
        {
            await _auth.InsertOneAsync(user);
        }
    }
}
