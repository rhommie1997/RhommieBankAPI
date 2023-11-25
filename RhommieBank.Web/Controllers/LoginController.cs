using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.ViewModels;
using System.Security.Claims;

namespace RhommieBank.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService _ls)
        {
            loginService = _ls;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal cUser = HttpContext.User;

            if (cUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel user)
        {
            ResponseDto? result = await loginService.GetResult(user);

            

            if(result != null)
            {
                if (result.IsSuccess)
                {
                    List<Claim> claims = new List<Claim>();

                    if (result.Result != null)
                    {
                        UserViewModel uvm = JsonConvert.DeserializeObject<UserViewModel>(Convert.ToString(result.Result));
                        claims.Add(new Claim("username", uvm.username ?? ""));
                        claims.Add(new Claim("password", uvm.username ?? ""));
                        claims.Add(new Claim("email", uvm.email ?? ""));
                        claims.Add(new Claim("nickname", uvm.nickname ?? ""));
                        claims.Add(new Claim("isAdmin", uvm.isAdmin.ToString()));
                        claims.Add(new Claim("imagePath", uvm.imagePath ?? ""));
                        claims.Add(new Claim("token", uvm.Token ?? ""));
                    }

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    //List<Claim> myClaims = (List<Claim>)claimsIdentity.Claims;

                    //Console.WriteLine("Ini " + claimsIdentity.Claims);
                    //Console.WriteLine("Ini " + myClaims[1].Value);

                    AuthenticationProperties proper = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = false
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), proper);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ValidateMessage"] = result.Message;
                    return View();
                }


            }
            else
            {
                ViewData["ValidateMessage"] = "Login Failed !!";
                return View();
            }
        }
    }

    
}
