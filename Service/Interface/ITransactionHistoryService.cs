using Coursework_BudgetMate.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Coursework_BudgetMate.Service.Interface
{
    public interface ITransactionHistoryService
    {
        Task<ObservableCollection<TransactionHistory>> GetTransactionHistoryAsync();
    }
}