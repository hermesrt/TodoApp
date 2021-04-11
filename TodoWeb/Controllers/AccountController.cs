using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NuGet.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoWeb.Models;

namespace TodoWeb.Controllers
{
    public class AccountController : Controller
    {
        public IConfiguration _configuration { get; }

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            using (var client = new HttpClient()
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("TodoWebApiUrl"))
            })
            {
                var tokenReq = await client.PostAsync("Auth/Login", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
                if (tokenReq.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.Name)
                };

                    var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {

                        RedirectUri = "/Home/Index",

                    };

                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                }
                return Redirect("/Accout/Error");

            }


        }

    }
}
