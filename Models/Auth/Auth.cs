using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Auth
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = "";
        public string Name { get; set; } = "";
        public bool IsActive { get; set; } = false;
        public string Token { get; set; } = "";
        public string Password { get; set; } = "";

        public User(string userName, string name, string password)
        {
            UserName = userName;
            Name = name;
            Password = password;
        }
    }

    public class LoginUser
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class RegisterUser
    {
        public string Name { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";

    }
}
