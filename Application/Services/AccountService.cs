using graphql_account_service.Application.Interfaces;
using graphql_account_service.Domain.Entities;

namespace graphql_account_service.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> CreateAccountAsync(string accountNumber, string customerId)
        {
            var account = new Account { AccountNumber = accountNumber, CustomerId = customerId, Balance = 0 };
            await _accountRepository.AddAccountAsync(account);
            return account;
        }

        public async Task<decimal> GetBalanceAsync(string accountNumber)
        {
            var account = await _accountRepository.GetAccountByNumberAsync(accountNumber);
            return account?.Balance ?? 0;
        }

        public async Task<decimal> DepositAsync(string accountNumber, decimal amount)
        {
            return await _accountRepository.DepositToAccountAsync(accountNumber, amount);
        }

        public async Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            return await _accountRepository.TransferAsync(fromAccountNumber, toAccountNumber, amount);
        }

        public async Task<Account> GetAccountAsync(string accountNumber)
        {
            return await _accountRepository.GetAccountByNumberAsync(accountNumber);
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAccountsAsync();
        }
    }
}