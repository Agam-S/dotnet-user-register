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
    public IEnumerable<User> GetUsers() {
    List<User> userList = new List<User>();

    var connection = new SqliteConnection("Data Source=User.db");
    
    connection.Open();
    
    var command = connection.CreateCommand();

    command.CommandText =
    @"
        SELECT *
        FROM User
    ";

    var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var Name = reader.GetString(0);
            var UserName = reader.GetString(1);
            var Email = reader.GetString(2);
            var Password = reader.GetString(3);
            

            userList.Add(new User(Name, UserName, Email, Password));
            
        }
    
        return userList;
    }
    [HttpPost(Name = "CreateUser")]
    public String CreateUser(User newUser) {


    var connection = new SqliteConnection("Data Source=User.db");
    
    connection.Open();
    
    var command = connection.CreateCommand();

    command.CommandText =
    @"
        INSERT INTO User(Name, UserName, Email, Password)
        VALUES($Name, $UserName, $Email, $Password)
    ";
    command.Parameters.AddWithValue("$Name", newUser.Name);
    command.Parameters.AddWithValue("$UserName", newUser.UserName);
    command.Parameters.AddWithValue("$Email", newUser.Email);
    command.Parameters.AddWithValue("$Password", newUser.Password);
   

        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected == -1){
            return $"Error";}else{
                return $"{newUser}";}
    }

    
}
