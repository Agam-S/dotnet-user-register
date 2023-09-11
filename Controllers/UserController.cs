using Microsoft.AspNetCore.Mvc;
namespace dotnet_user_register.Controllers;
using dotnet_user_register.models;


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
    public String GetUser()
    {
        return "Hello";
       
    }
    [HttpPost(Name = "CreateUser")]
    public String CreateUser() {
         return "Hello"; 
    }
}
