using Coursework_BudgetMate.Model;
using Coursework_BudgetMate.Service.Interface;
using Microsoft.AspNetCore.Components;

namespace Coursework_BudgetMate.Components.Pages;

public partial class TransactionHistory
{
    private List<Model.TransactionHistory>? _transactionHistoryList;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    private ITransactionHistoryService TransactionHistoryService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var transactions = await TransactionHistoryService.GetTransactionHistoryAsync();
            _transactionHistoryList = transactions.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading transaction history: {ex.Message}");
            _transactionHistoryList = new List<Model.TransactionHistory>();
        }
    }

    private void Logout()
    {
        NavigationManager.NavigateTo("/");
    }
}