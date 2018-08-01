using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProteinStore.Models;
using Microsoft.AspNetCore.Identity;


namespace ProteinStore.Controllers
{
    public class AccountController : Controller
    {
        SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        //htttpGET
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser(model.UserName);

                IdentityResult creationResult = this._signInManager.UserManager.CreateAsync(newUser).Result;
                if (creationResult.Succeeded)
                {
                    IdentityResult passwordResult = this._signInManager.UserManager.AddPasswordAsync(newUser, model.Password).Result;
                    if (passwordResult.Succeeded)
                    {
                        this._signInManager.SignInAsync(newUser, false).Wait();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in creationResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View();

        }

        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser existingUser = this._signInManager.UserManager.FindByNameAsync(model.UserName).Result;
                if (existingUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult passwordResult = this._signInManager.CheckPasswordSignInAsync(existingUser, model.Password, false).Result;
                    if (passwordResult.Succeeded)
                    {
                        this._signInManager.SignInAsync(existingUser, false).Wait();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("PasswordIncorrect", "Username or Password is incorrect.");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserDoesNotExist", "Username or Password is incorrect.");

                }
            }
            return View();

        }


    }
}