using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA1.Data;
using DA1.Models.Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using DA1.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System.Text;


namespace DA1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;  

        public LoginController(DataContext context)
        {
            _context = context;
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(User objUser)
        {



            var obj = _context.Users.Where(a => a.Username.Equals(objUser.Username) && a.pass.Equals(objUser.pass)).FirstOrDefault();
            if (obj != null)
            {
                List<Claim> claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name,objUser.Username),
                new Claim(ClaimTypes.Name,objUser.pass ),
                new Claim(ClaimTypes.Role,"admin")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                return RedirectToAction("Index","Products");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}
