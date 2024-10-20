using graphql_account_service.Domain.Entities;

namespace graphql_account_service.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(string accountNumber, string customerId);
        Task<decimal> GetBalanceAsync(string accountNumber);
        Task<decimal> DepositAsync(string accountNumber, decimal amount);
        Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount);
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountAsync(string accountNumber);
    }
}