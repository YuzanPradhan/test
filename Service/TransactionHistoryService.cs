using Coursework_BudgetMate.Model;
using Coursework_BudgetMate.Service.Interface;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Coursework_BudgetMate.Service
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly IFileSystem _fileSystem;

        public TransactionHistoryService()
        {
            _fileSystem = FileSystem.Current;
        }

        public async Task<ObservableCollection<TransactionHistory>> GetTransactionHistoryAsync()
        {
            var transactionHistory = new ObservableCollection<TransactionHistory>();
            try
            {
                using var stream = await _fileSystem.OpenAppPackageFileAsync("wwwroot/Data/transactionhistory.json");
                using var reader = new StreamReader(stream);
                var jsonContent = await reader.ReadToEndAsync();
                var transactionList = JsonSerializer.Deserialize<List<TransactionHistory>>(jsonContent);

                if (transactionList != null)
                {
                    foreach (var transaction in transactionList)
                    {
                        transactionHistory.Add(transaction);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading transaction history: {ex.Message}");
            }
            return transactionHistory;
        }
    }
}