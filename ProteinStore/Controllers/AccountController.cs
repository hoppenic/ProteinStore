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
                //Come back here and make it so we log user in
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}