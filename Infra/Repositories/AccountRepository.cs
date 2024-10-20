using graphql_account_service.Application.Interfaces;
using graphql_account_service.Domain.Entities;

namespace graphql_account_service.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new List<Account>();

        public Task<Account> GetAccountByNumberAsync(string accountNumber)
        {
            return Task.FromResult(_accounts.FirstOrDefault(a => a.AccountNumber == accountNumber));
        }

        public Task<List<Account>> GetAllAccountsAsync()
        {
            return Task.FromResult(_accounts.ToList());
        }

        public Task AddAccountAsync(Account account)
        {
            _accounts.Add(account);
            return Task.CompletedTask;
        }

        public Task<decimal> DepositToAccountAsync(string accountNumber, decimal amount)
        {
            var account = _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Balance += amount;
            }
            return Task.FromResult(account.Balance);
        }

        public async Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            var fromAccount = await GetAccountByNumberAsync(fromAccountNumber);
            var toAccount = await GetAccountByNumberAsync(toAccountNumber);

            if (fromAccount == null || toAccount == null || fromAccount.Balance < amount)
            {
                return false; // Insufficient funds or account not found
            }

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            return true; // Transfer successful
        }
    }
}