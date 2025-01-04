using Microsoft.AspNetCore.Components;

namespace Coursework_BudgetMate.Components.Pages;

public partial class Dashboard
{
    
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;
    private void Logout()
    {
        NavigationManager.NavigateTo("/");
    }
}