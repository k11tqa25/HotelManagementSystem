using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace WenKaiTsai.HotelManagementSystem.HotelManagementSystemMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminService _adminService;

        public AccountController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Model Binding: paramter matches the incoming key (not case-sensitive)
        [HttpPost]
        public async Task<IActionResult> Register(AdminRegisterRequestModel model)
        {
            // Save only if the data pass the model validation
            if (!ModelState.IsValid)
            {
                return View();
            }

            var createdUser = await _adminService.RegisterUserAsync(model);

            // Redirect to Login page
            return RedirectToAction(nameof(Login));

        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(AdminLoginRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _adminService.LoginAsync(requestModel);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid password");
                return View();
            }

            // correct password
            // display account info,  Logout  button
            // Cookie Based Authentication...
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
            };

            // Identity object
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Create the cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            // Redirect to home page
            return LocalRedirect("~/");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
