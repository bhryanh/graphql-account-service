using graphql_account_service.Application.Interfaces;
using graphql_account_service.Domain.Entities;

namespace graphql_account_service.Api.GraphQL
{
    public class Mutation
    {
        private readonly IAccountService _accountService;

        public Mutation(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Account> CreateAccount(string accountNumber, string customerId)
        {
            return await _accountService.CreateAccountAsync(accountNumber, customerId);
        }

        public async Task<bool> Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            return await _accountService.TransferAsync(fromAccountNumber, toAccountNumber, amount);
        }

        public async Task<decimal> Deposit(string accountNumber, decimal amount)
        {
            return await _accountService.DepositAsync(accountNumber, amount);
        }
    }
}