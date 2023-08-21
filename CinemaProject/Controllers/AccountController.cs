using CinemaProject.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCTask2Day02.Repository;
using System.Data;
using System.Security.Claims;
using CinemaProject.ViewModel;

namespace CinemaProject.Controllers
{
    public class AccountController : Controller
    {
            
            IAccountRepository _accountRepo;
            public AccountController(IAccountRepository accountREpo)//inject
            {
            _accountRepo = accountREpo;
            }
         
            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Register(RegisterUserViewModel newAccount)
            {
                if (ModelState.IsValid)
                {
                    Account account = new Account();
                    account.UserName = newAccount.UserName;
                    account.Password = newAccount.Password;

                _accountRepo.Create(account);
                _accountRepo.Save();
                    //Cookie :Custome Identity base claims 
                    ClaimsIdentity claims = new ClaimsIdentity
                        (CookieAuthenticationDefaults.AuthenticationScheme); 
                    claims.AddClaim(new Claim(ClaimTypes.Name, account.UserName));
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()));
                  
                    claims.AddClaim(new Claim(ClaimTypes.Role, _accountRepo.GetRoles(account.Id)));

                    ClaimsPrincipal principle = new ClaimsPrincipal(claims);
                    
                    HttpContext.SignInAsync
                        (CookieAuthenticationDefaults.AuthenticationScheme, principle);

                    return RedirectToAction("Index", "Movies");
                    
                }
                return View(newAccount);
            }

            [Authorize(Roles = "Admin")]
            public IActionResult ShowUserData()
            {
                return Content("Welecom" + User.Identity.Name);
            }

            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Login(Account account)
            {
                if (_accountRepo.Find(account.UserName, account.Password))
                {
                    //get account
                    Account AccountModel = _accountRepo.Get(account.UserName, account.Password);
                    //create cookie
                    ClaimsIdentity claims =
                        new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    claims.AddClaim(
                        new Claim(ClaimTypes.NameIdentifier, AccountModel.Id.ToString()));
                    claims.AddClaim(
                        new Claim(ClaimTypes.Name, AccountModel.UserName.ToString()));
                    claims.AddClaim(
                        new Claim(ClaimTypes.Role, _accountRepo.GetRoles(AccountModel.Id)));



                    ClaimsPrincipal principle =
                        new ClaimsPrincipal(claims);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                   
                    return RedirectToAction("Index", "Movies");

                }
                return View(account);
            }

            public IActionResult SignOut()
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login");
            }
        }
}
