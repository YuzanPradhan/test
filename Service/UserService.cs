using Coursework_BudgetMate.Abstraction;
using Coursework_BudgetMate.Model;
using Coursework_BudgetMate.Service.Interface;

namespace Coursework_BudgetMate.Service;

public class UserService : Userbase, IUserService
{
    private List<User> _users;

    private const string SeedUsername = "admin";
    private const string SeedPassword = "password";

    public UserService()
    {
        string filename = FileSystem.AppDataDirectory;
        Console.WriteLine(filename);
        _users = LoadUser();
        if (!_users.Any())
        {
            _users.Add(new User { Username = SeedUsername, Password = SeedPassword });
            SaveUser(_users);
        }
    }

    public bool Login(User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return false;
        }

        return _users.Any(u => u.Username == user.Username && u.Password == user.Password);
    }

    public bool Register(User user)
    {
        throw new NotImplementedException();
    }
}
