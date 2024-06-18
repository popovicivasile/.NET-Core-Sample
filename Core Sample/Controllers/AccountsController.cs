using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core_Sample.Context;
using Core_Sample.Context.Models;
using Core_Sample.Repository.Abstract;

namespace Core_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccount _accountRepository;

        public AccountsController(IAccount accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(String Name, String Email, int maxMachines)
        {

            try
            {
                Account accounts = new Account
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    Email = Email,
                    CreatedDate = DateTime.Now,
                    maxMachines = maxMachines
                };

                await _accountRepository.CreateAccount(accounts);

            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the account.");

            }
            return Ok("AccountCreated");

        }



    }
}
