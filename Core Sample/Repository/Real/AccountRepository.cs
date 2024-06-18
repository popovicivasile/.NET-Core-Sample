using Core_Sample.Repository.Abstract;
using Core_Sample.Context;
using Core_Sample.Context.Models;

namespace Core_Sample.Repository.Real
{
    public class AccountRepository : IAccount
    {
        private readonly ServiceContext _context;


        public AccountRepository(ServiceContext context)
        {
            _context = context;
        }

        public async Task CreateAccount(Account acount)
        {
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                Name = acount.Name,
                Email = acount.Email,
                CreatedDate = DateTime.Now,
                maxMachines = acount.maxMachines
            };

            _context.Account.Add(account);
            await _context.SaveChangesAsync();
        }




    }
}
