using Coursework_BudgetMate.Model;

namespace Coursework_BudgetMate.Service.Interface;

public interface IUserService
{
    bool Login(User user);
    bool Register(User user);
}