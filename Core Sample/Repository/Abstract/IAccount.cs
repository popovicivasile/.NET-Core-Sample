using Core_Sample.Context.Models;   

namespace Core_Sample.Repository.Abstract
{
    public interface IAccount
    {

        Task CreateAccount(Account account);


    }
}
