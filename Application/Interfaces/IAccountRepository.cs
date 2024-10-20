using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphql_account_service.Domain.Entities;

namespace graphql_account_service.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByNumberAsync(string accountNumber);
        Task<decimal> DepositToAccountAsync(string accountNumber, decimal amount);
        Task AddAccountAsync(Account account);
        Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount);
    }
}