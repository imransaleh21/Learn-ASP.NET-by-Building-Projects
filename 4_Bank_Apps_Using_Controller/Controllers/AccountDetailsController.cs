using Microsoft.AspNetCore.Mvc;
using _4_Bank_Apps_Using_Controller.Models;

namespace _4_Bank_Apps_Using_Controller.Controllers
{
    public class AccountDetailsController : Controller
    {
        // Store accounts as a static field so all actions can access
        private static readonly Dictionary<string, Accounts> accounts = new()
            {
                { "101", new Accounts
                    {
                        AccountNumber = "101",
                        Name = "Imran Saleh",
                        Balance = 1000.00,
                        AccountType = "Savings"
                    }
                },
                { "102", new Accounts
                    {
                        AccountNumber = "102",
                        Name = "",
                        Balance = 2000.00,
                        AccountType = "Current"
                    }
                }
            };

        [Route("/")]
        public IActionResult Home()
        {
            return Content("Welcome to the Bank App");
        }

        [Route("account-details/{accountId?}")]
        public IActionResult AccountInfo(string? accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                return NotFound("Account ID is required");
            }

            else if (accounts.TryGetValue(accountId, out var account))
            {
                return Json(account);
            }
            else
            {
                return BadRequest($"Account with ID {accountId} not found");
            }
        }

        [Route("account-statements")]
        public IActionResult AccountStatement()
        {
            return Content("Account Statement");
        }

        [Route("account-balance/{accountId?}")]
        public IActionResult AccountBalance(string? accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                return NotFound("Account ID is required");
            }

            else if (accounts.TryGetValue(accountId, out var account))
            {
                return Content(account.Balance.ToString(), "application/text");
            }
            else
            {
                return BadRequest($"Account with ID {accountId} not found");
            }
        }
    }
}
