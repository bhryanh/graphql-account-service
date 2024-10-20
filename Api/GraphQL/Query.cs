using graphql_account_service.Application.Interfaces;
using graphql_account_service.Domain.Entities;

namespace graphql_account_service.Api.GraphQL
{
    public class Query
    {
        private readonly IAccountService _accountService;

        public Query(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Account> GetAccount(string accountNumber)
        {
            return await _accountService.GetAccountAsync(accountNumber);
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _accountService.GetAllAccountsAsync();
        }

        public async Task<decimal> GetBalance(string accountNumber)
        {
            return await _accountService.GetBalanceAsync(accountNumber);
        }
    }
}