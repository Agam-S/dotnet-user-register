using Microsoft.AspNetCore.Mvc;
namespace dotnet_user_register.Controllers;

using System.Data;
using dotnet_user_register.models;
using Microsoft.Data.Sqlite;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<User> GetUsers()
    {
    List<User> userList = new List<User>();
    User listedUser = new User();

    var connection = new SqliteConnection("Data Source=User.db");
    
    connection.Open();
    
    var command = connection.CreateCommand();

    command.CommandText =
    @"
        SELECT *
        FROM user
    ";

    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            var name = reader.GetString(0);
            var userName = reader.GetString(1);
            var email = reader.GetString(2);
            var password = reader.GetString(3);

            Console.WriteLine($"{name} - {userName}");
            
            listedUser.Name = name;
            listedUser.UserName = userName;
            listedUser.Email = email;
            listedUser.Password = password;

            userList.Add(listedUser);

        }
    }
    return userList;
    }
    [HttpPost(Name = "CreateUser")]
    public String CreateUser() {
         return "Hello"; 
    }
}
