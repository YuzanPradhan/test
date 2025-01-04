using Coursework_BudgetMate.Model;
using Coursework_BudgetMate.Service;
using Microsoft.AspNetCore.Components;

namespace Coursework_BudgetMate.Components.Pages;

public partial class Login
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    private User Users { get; set; } = new User();
    
    private UserService _userService = new UserService();
    
    private string? _errorMessage;

    private void HandleLogin()
    {
        try
        {
            if (_userService.Login(Users))
            {
                NavigationManager.NavigateTo("/dashboard");
            }
            else
            {
                _errorMessage = "Invalid username or password";
            }
        }
        catch (Exception ex)
        {
            _errorMessage = "An error occurred during login. Please try again.";
            Console.WriteLine($"Login error: {ex.Message}");
        }
    }
}