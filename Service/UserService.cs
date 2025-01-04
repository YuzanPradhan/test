using Coursework_BudgetMate.Abstraction;
using Coursework_BudgetMate.Model;
using Coursework_BudgetMate.Service.Interface;
using System.Text.Json;

namespace Coursework_BudgetMate.Service;

public class UserService : Userbase, IUserService
{
    private List<User> _users;
    private readonly User _defaultCredentials;

    public UserService()
    {
        string filename = FileSystem.AppDataDirectory;
        Console.WriteLine(filename);
        
        // Load default credentials from JSON
        string credentialsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "credentials.json");
        string jsonContent = File.ReadAllText(credentialsPath);
        _defaultCredentials = JsonSerializer.Deserialize<User>(jsonContent) ?? throw new InvalidOperationException("Failed to load default credentials");

        _users = LoadUser();
        if (!_users.Any())
        {
            _users.Add(new User 
            { 
                Username = _defaultCredentials.Username, 
                Password = _defaultCredentials.Password 
            });
            SaveUser(_users);
        }
    }

    public bool Login(User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return false;
        }

        // Strictly compare with credentials from json file
        return user.Username == _defaultCredentials.Username && 
               user.Password == _defaultCredentials.Password;
    }

    public bool Register(User user)
    {
        throw new NotImplementedException();
    }
}
