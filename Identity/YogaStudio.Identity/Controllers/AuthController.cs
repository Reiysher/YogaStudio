using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YogaStudio.Identity.Models;

namespace YogaStudio.Identity.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager,
            IIdentityServerInteractionService interactionService,
            IHttpClientFactory httpClientFactory) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _interactionService = interactionService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl);
                }
                else
        {
                    ModelState.AddModelError(string.Empty, "User not found");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var model = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                var item = new StringContent(JsonSerializer.Serialize(user), 
                    Encoding.UTF8, "application/json");
                var client = _httpClientFactory.CreateClient();
                await client.PostAsync("https://localhost:44328/api/1.0/client", item);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("https://localhost:44328/");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService
                .GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
