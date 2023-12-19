using Business.Abstract;
using DTO.DTOEntity;
using Helper.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebCards.asb.az.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = RoleKeywords.AdminRole)]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserDTO us)
        {
            us.ImageURL = "user.png";
            us.Create = DateTime.Now;
            _userService.Insert(us);

            return RedirectToAction("SignIn", "Login");
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserDTO us)
        {
            var user=_userService.Login(us);
            Authenticate(user);
            return RedirectToAction("Index","Home");
        }



        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn", "Login");
        }

        //Cookie
        private void Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id",user.ID.ToString()),
                new Claim("UserName",user.UserName),
                new Claim(ClaimTypes.Role,user.RoleName),
            };

            ClaimsIdentity id=new ClaimsIdentity(claims,"ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
