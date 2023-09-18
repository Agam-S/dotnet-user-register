namespace dotnet_user_register.models;

public class User
{
    public User(string name, string username, string email, string password)
    {
        Name = name;
        UserName = username;
        Email = email;
        Password = password;
    }

    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
