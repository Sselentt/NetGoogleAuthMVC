﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetGoogleAuthMVC.Models;
using NetGoogleAuthMVC.Models.ViewModels;
using System.Diagnostics;

namespace NetGoogleAuthMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger,UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            if(ModelState.IsValid)
            {
                IdentityUser ıdentityUser = new IdentityUser
                {
                    UserName=registerVM.Username,
                    Email=registerVM.Email,
                };

                var result = await _userManager.CreateAsync(ıdentityUser,registerVM.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return View(registerVM);
            } 
            else
            {
                return View(registerVM);
            }

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}