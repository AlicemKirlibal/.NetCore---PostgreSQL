using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapitsoft.ApiService;
using testapitsoft.Helpers;
using testapitsoft.Models;

namespace testapitsoft.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthApiService _authApiService;
        private readonly SessionHelper _sessionHelper;

        public AuthController(AuthApiService authApiService,SessionHelper sessionHelper)
        {
            _authApiService = authApiService;
            _sessionHelper = sessionHelper;
        }


        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var response = await _authApiService.Login(model);
            if (!response.Data.Any())
            {
                return View(model);
            }

            _sessionHelper.Login(response.Data.FirstOrDefault());

            return RedirectToAction("Index", "Order");
        }

    }
}
